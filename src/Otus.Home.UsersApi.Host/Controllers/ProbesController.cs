using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Home.UsersApi.Core.Domain.Administration;
using Otus.Home.UsersApi.Host.Models;

namespace Otus.Home.UsersApi.Host.Controllers
{
	/// <summary>
	/// Пользователи
	/// </summary>
	[ApiController]
	public class ProbesController : ControllerBase
	{
		/// <summary>
		/// Точка для хелсчека
		/// </summary>
		[HttpGet]
		[Route("health")]
		public Task<ActionResult> GetHealth()
		{
			return Task.FromResult<ActionResult>(Ok(new
			{
				status = "OK"
			}));
		}
	}
}