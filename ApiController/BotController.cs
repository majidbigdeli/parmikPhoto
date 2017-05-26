using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Photo.Effect.DataContract;
using Photo.Server.TesterFromCsharp;
using System.IO;
using PamikPhoto;
using Parmik.CS.Core.Image;
using Telegram.Bot;
using Telegram.Bot.Types;
using majidParmikPhoto;
using majidParmikPhoto.Utility;

namespace WebApplication28.ApiController
{
    public class BotController : Controller
    {
        static TelegramBotClient effectBot = new TelegramBotClient("344301079:AAHi43XVL2PhZ9eRmC_4jTPzKWA8o5WXfLw");
        modelrespa vm = new modelrespa();
        private readonly IHostingEnvironment _hostingEnvironment;
        public BotController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public void Get()
        {
        }
        [HttpPost]
        public async Task<object> Post([FromBody]SimplePhotoEffect value)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            try
            {
                var image = CardF(value);
                var myUniqueFileName = string.Format(@"{0}.jpg", DateTime.Now.Ticks);
                image.Save(webRootPath + @"/img/" + myUniqueFileName);
                vm.Link = "../img/" + myUniqueFileName;
                vm.Name = "tg://resolve?domain=parmikphotobot&start=" + myUniqueFileName;
                return vm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public async Task<object> Postb([FromBody]SimplePhotoEffect value)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            try
            {
                var image = Card(value);
                var myUniqueFileName = string.Format(@"{0}.jpg", DateTime.Now.Ticks);
                image.Save(webRootPath + @"/img/" + myUniqueFileName);
                vm.Link = "../img/" + myUniqueFileName;
                vm.Name = "tg://resolve?domain=parmikphotobot&start=" + myUniqueFileName;
                return vm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public async Task<object> PostHappy([FromBody]SimplePhotoEffect value)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            try
            {
                var image = CardHappy(value);
                var myUniqueFileName = string.Format(@"{0}.jpg", DateTime.Now.Ticks);
                image.Save(webRootPath + @"/img/" + myUniqueFileName);
                vm.Link = "../img/" + myUniqueFileName;
                vm.Name = "tg://resolve?domain=parmikphotobot&start=" + myUniqueFileName;
                return vm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Image Card(SimplePhotoEffect md)
        {
            if (md.Effect == Effects.TextAdder)
            {
                var datadir = @"D:\HostingSpaces\majidbigdeli\cardpostal.parmik.com\wwwroot\wwwroot\data\";
                if (md.Level != null)
                    return PostalCard.Instance(datadir).GetCard(md.Signature, md.Text, (int)md.Level.Value);
            }
            return null;
        }
        private Image CardF(SimplePhotoEffect md)
        {
            if (md.Effect == Effects.TextAdder)
            {
                var datadir = @"D:\HostingSpaces\majidbigdeli\cardpostal.parmik.com\wwwroot\wwwroot\data\Father\";
                if (md.Level != null)
                    return PostalCardF.Instance(datadir).GetCard(md.Signature, md.Text, (int)md.Level.Value);
            }
            return null;
        }
        private Image CardHappy(SimplePhotoEffect md)
        {
            if (md.Effect == Effects.TextAdder)
            {
                var datadir = @"D:\HostingSpaces\majidbigdeli\cardpostal.parmik.com\wwwroot\wwwroot\data\Happy\";
                if (md.Level != null)
                    return PostalHappyCard.Instance(datadir).GetCard(md.Signature, md.Text, (int)md.Level.Value);
            }
            return null;
        }

    }
}
