
using labWork22.Data;
using labWork22.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace labWork22
{
    internal class PhotosLoadDb
    {
        internal bool stateOperation;
        internal string image;
        internal PhotosLoadDb(string game,string uriLogo)
        {
            using var context = new Ispp0104Context();
            var gameId = context.Lw22Games.ToList().DefaultIfEmpty(null)
                                                   .FirstOrDefault(entity => game == entity.Name).IdGame;
            
            Lw22Photo? photoInfoGame = null;
            if (context.Lw22Photos.ToList().Count != 0)
            {
                photoInfoGame = context.Lw22Photos.ToList().DefaultIfEmpty(null)
                                                         .FirstOrDefault(entity => gameId == entity.IdPhoto);
            }
            uriLogo = uriLogo.Replace("bin\\Debug\\net6.0-windows\\","\\games\\logos");
            var file = new FileInfo(uriLogo);
            byte[] imageData;
            if (file.Length / Math.Pow(1024, 2) > 10)
                return;

            using (FileStream fs = new(uriLogo, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            if (photoInfoGame == null)
            {
                context.Lw22Photos.Add(new Lw22Photo() { FileName = uriLogo, IdGame = gameId, IdPhoto = gameId, Photo = imageData});
                context.SaveChanges();
            }
            else
            {
                photoInfoGame.FileName = uriLogo;
                photoInfoGame.Photo = imageData;
                context.SaveChanges();
            }
            image = uriLogo;
            stateOperation = true;
        }
    }
}
