using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;

namespace Photo.Server.TesterFromCsharp
{
    public class PostalCard
    {
        private List<Bitmap> cards;
        String fontName;
        FontFamily ff;
        private string p;
        public PostalCard(string workingDir)
        {
            try
            {
                int cardNumbers = 6;
                int textNumbers = 2;
                cards = new List<Bitmap>(12);
                // int cnt = 0;
                for (int j = 1; j <= textNumbers; j++)
                {
                    for (int i = 1; i <= cardNumbers; i++)
                    {
                        cards.Add(new Bitmap((workingDir + "\\" + "t" + j.ToString() + "c" + i.ToString() + ".png")));
                        //cnt++;
                    }
                }
                fontName = (workingDir + "\\" + "IranNastaliq.ttf");
                PrivateFontCollection pfcoll = new PrivateFontCollection();
                pfcoll.AddFontFile(fontName);

                ff = (pfcoll.Families[0]);
            }
            catch (Exception e)
            {
            }

        }
        public Bitmap GetCard(string Signature, string BodyText, int CardNumber)
        {
            int fileNumber;
            bool HasBody = false;
            try
            {
                if (BodyText == "1")
                {
                    fileNumber = CardNumber - 1;
                }

                else
                {
                    fileNumber = CardNumber + 6 * 1 - 1;
                    HasBody = true;
                }

                Bitmap card = new Bitmap((Image)cards[fileNumber].Clone());

                lock (card)
                {
                    if (HasBody)
                    {
                        RectangleF bodyRect = new RectangleF(130, 130, 540, 350);
                        StringFormat bodyStringFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                        bodyStringFormat.Alignment = StringAlignment.Near;
                        bodyStringFormat.LineAlignment = StringAlignment.Near;
                        Font font = new Font(ff, 20, FontStyle.Bold);
                        Graphics graphics = Graphics.FromImage(card);
                        graphics.DrawString(BodyText, font, new SolidBrush(Color.Black), bodyRect, bodyStringFormat);
                        StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        RectangleF myrect = new RectangleF(140, 470, 320, 150);
                        graphics.DrawString(Signature, font, new SolidBrush(Color.Black), myrect, stringFormat);
                        PointF drawPoint = new PointF(10.0F, card.Height - 40.0F);
                        graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(9, card.Height - 38, 220, 32));
                        graphics.DrawString("@ParmikPhotoBot", new Font("Times", 20), new SolidBrush(Color.Red), drawPoint);
                    }
                    else
                    {
                        Font font = new Font(ff, 20, FontStyle.Bold);
                        Graphics graphics = Graphics.FromImage(card);
                        StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        RectangleF myrect = new RectangleF(140, 470, 320, 150);
                        StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                        graphics.DrawString(Signature, font, new SolidBrush(Color.Black), myrect, stringFormat);
                        PointF drawPoint = new PointF(10.0F, card.Height - 40.0F);
                        graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(9, card.Height - 38, 220, 32));
                        graphics.DrawString("@ParmikPhotoBot", new Font("Times", 20), new SolidBrush(Color.Red), drawPoint);
                    }
                }
                return card;
            }
            catch (Exception e)
            {
                //String FilePathLog = HttpContext.Current.Server.MapPath(@"../../data/" + "CSCardMaker.log");
                //File.AppendAllText(DateTime.Now.ToString() + " :" + FilePathLog, e.ToString());
                return null;
            }
        }
        private static PostalCard _postal;
        private static object syncRoot = new Object();
        public static PostalCard Instance(string dir)
        {
            if (_postal == null)
            {
                lock (syncRoot)
                {
                    if (_postal == null)
                        _postal = new PostalCard(dir);
                }
                _postal = new PostalCard(dir);
            }
            return _postal;
        }
    }
}