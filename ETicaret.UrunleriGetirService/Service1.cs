using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ETicaret.UrunleriGetirService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            this.CanPauseAndContinue = true;
        }

        private Timer timer=new Timer();//Service için zaman ayarı yapan class/nesne


        public void Debug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            //Service çalıştığında çalışacak kodlar
            //ürünler
            //
            //mail gönderimi service ile yapalım=>
            timer.Interval = 30000;//30 saniyede 1 kez çalışacaktır
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);//Service 30 saniye de 1 kez dönüşümlü çalışmasını sağlayan yapıdır
            timer.Enabled = true;//aktif et
            timer.Start();//zamanlayıcıyı çalıştırır




        }

        void Timer_Elapsed(object nesne,ElapsedEventArgs args)
        {
            MailGonder();
        }

        protected override void OnStop()
        {
            //Service kapandığında çalışacak kodlar
        }



        void MailGonder()
        {

        }

        void StokTakibi()
        {

        }


    }
}
