﻿using System;
using System.Web.Mvc;

namespace AnalyticsGames.Web.Controllers
{
    public class GameController : Controller
    {
        public ActionResult WaitPlayer()
        {
            var gameId = Guid.NewGuid();
            var callBackUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}{Url.Action("Player", "Game", new { id = gameId })}";
            ViewBag.GameId = gameId;
            ViewBag.CallBackUrl = callBackUrl;
            ViewBag.ImageUrl = $"https://api.qrserver.com/v1/create-qr-code/?color=000000&bgcolor=FFFFFF&data={Uri.EscapeUriString(callBackUrl)}&qzone=1&margin=0&size=600x600&ecc=L&format=png";
            return View();
        }

        [HttpGet]
        public ActionResult Player(string id)
        {
            ViewBag.gameId = id;
            return View();
        }

        [HttpGet]
        public ActionResult Run(string id)
        {
            ViewBag.gameId = id;
            return View();
        }
    }
}
