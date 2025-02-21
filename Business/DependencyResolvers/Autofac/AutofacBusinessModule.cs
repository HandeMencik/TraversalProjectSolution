using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<TraversalContext>();
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-44V5O40\SQLEXPRESS; Database=TraversalDb; Integrated Security=True; TrustServerCertificate=True;");

            //builder.Register(c => new TraversalContext(optionsBuilder.Options)).InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TraversalContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-44V5O40\\SQLEXPRESS;Database=TraversalDb;Integrated Security=True;TrustServerCertificate=True;");
                return new TraversalContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<DestinationManager>().As<IDestinationService>().SingleInstance();
            builder.RegisterType<EfDestinationDal>().As<IDestinationDal>().SingleInstance();

            builder.RegisterType<SubAboutManager>().As<ISubAboutService>().SingleInstance();
            builder.RegisterType<EfSubAboutDal>().As<ISubAboutDal>().SingleInstance();

            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>().SingleInstance();


            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<ReservationManager>().As<IReservationService>().SingleInstance();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().SingleInstance();

            builder.RegisterType<GuideManager>().As<IGuideService>().SingleInstance();
            builder.RegisterType<EfGuideDal>().As<IGuideDal>().SingleInstance();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().SingleInstance();
            builder.RegisterType<EfAppUserDal>().As<IAppUserDal>().SingleInstance();

            builder.RegisterType<ExcelManager>().As<IExcelService>().SingleInstance();
            builder.RegisterType<PdfManager>().As<IPdfService>().SingleInstance();

            builder.RegisterType<ContactUsManager>().As<IContactUsService>().SingleInstance();
            builder.RegisterType<EfContactUsDal>().As<IContactUsDal>().SingleInstance();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().SingleInstance();


        }
    }
}