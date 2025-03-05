using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using DataAccess.UnitOfWork;
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

            builder.RegisterType<DestinationManager>().As<IDestinationService>().InstancePerLifetimeScope();
            builder.RegisterType<EfDestinationDal>().As<IDestinationDal>().InstancePerLifetimeScope();

            builder.RegisterType<SubAboutManager>().As<ISubAboutService>().InstancePerLifetimeScope();
            builder.RegisterType<EfSubAboutDal>().As<ISubAboutDal>().InstancePerLifetimeScope();

            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().InstancePerLifetimeScope();
            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>().InstancePerLifetimeScope();


            builder.RegisterType<CommentManager>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().InstancePerLifetimeScope();

            builder.RegisterType<ReservationManager>().As<IReservationService>().InstancePerLifetimeScope();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().InstancePerLifetimeScope();

            builder.RegisterType<GuideManager>().As<IGuideService>().InstancePerLifetimeScope();
            builder.RegisterType<EfGuideDal>().As<IGuideDal>().InstancePerLifetimeScope();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAppUserDal>().As<IAppUserDal>().InstancePerLifetimeScope();

            builder.RegisterType<ExcelManager>().As<IExcelService>().InstancePerLifetimeScope();
            builder.RegisterType<PdfManager>().As<IPdfService>().InstancePerLifetimeScope();

            builder.RegisterType<ContactUsManager>().As<IContactUsService>().InstancePerLifetimeScope();
            builder.RegisterType<EfContactUsDal>().As<IContactUsDal>().InstancePerLifetimeScope();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().InstancePerLifetimeScope();

            builder.RegisterType<AccountManager>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAccountDal>().As<IAccountDal>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


        }
    }
}