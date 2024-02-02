using System;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;
using SaoTsea.Ds.Api.Models.ParamModels;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BpmNotificationController : BetimesControllerBase
	{

		[XpoFilter]
		[HttpGet("{id}")]
		public Task<VIEW_NOTIFICATION> Get(int id)
		{
			return DB.GetObjectByKeyAsync<VIEW_NOTIFICATION>(id);
		}

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet]
		public Task<VIEW_NOTIFICATION[]> Gets([FromQuery] NotificationFilter filter)
		{
			IQueryable<VIEW_NOTIFICATION> query = DB.GetXpQuery<VIEW_NOTIFICATION>();
			if (filter.PersonalId.HasValue)
			{
				query = query.Where(_ => _.PERSONAL_ID == filter.PersonalId);
			}

			if (filter.UnRead == true)
			{
				query = query.Where(_ => _.FLAG_READ == "N");
			}

			return query.OrderByDescending(_ => _.NOTIFICATION_DATE)
			            .Skip(filter.Offset)
			            .Take(filter.Length).ToArrayAsync();
		}

		[AllowAnonymous]
		[XpoFilter]
		[HttpGet("unread/count")]
		public Task<int> GetNotificationCount([FromQuery] NotificationFilter filter)
		{
			IQueryable<BPM_NOTIFICATION_TO> query = DB.GetXpQuery<BPM_NOTIFICATION_TO>();
			if (filter.PersonalId.HasValue)
			{
				query = query.Where(_ => _.PERSONAL_ID == filter.PersonalId);
			}

			query = query.Where(_ => _.FLAG_READ == "N");

			return query.Take(100).CountAsync();
		}

		[AllowAnonymous]
		[XpoAutoUpdate]
		[HttpPost("send")]
		public async Task<StatusResult<int>> CreateAndSendTo(NotificationSendToParam value)
		{
			if (value.SendToPersonal == null)
			{
				return StatusResult.Error("ไม่พบข้อมูลการส่งถึง");
			}

			await DB.CommitChangesAsync();

			foreach (var personalId in value.SendToPersonal)
			{
				var notificationTo = new BPM_NOTIFICATION_TO(DB.Session)
				{
					NOTIFICATION_ID = value.Body.NOTIFICATION_ID,
					FLAG_READ = "N",
					PERSONAL_ID = personalId
				};

				DB.InsertObject(notificationTo);
			}

			await DB.CommitChangesAsync();
			return StatusResult.Ok(value.Body.NOTIFICATION_ID);
		}

		[AllowAnonymous]
		[HttpPost("read")]
		public async Task<StatusResult> SetRead(NotificationReadParam value)
		{
			var notificationTo = await DB.GetObjectByKeyAsync<BPM_NOTIFICATION_TO>(value.NotificationToId);
			if (notificationTo == null)
			{
				return StatusResult.Error("ไม่พบข้อมูลการแจ้งเตือน");
			}

			notificationTo.FLAG_READ = "Y";
			notificationTo.READ_DATE = DateTime.Now;

			await DB.CommitChangesAsync();
			return StatusResult.Ok();
		}
	}
}
