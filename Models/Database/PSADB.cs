using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PSA_MVC_V2.Models.Database
{
    public partial class PSADB : DbContext
    {
        public PSADB()
        {
        }

        public PSADB(DbContextOptions<PSADB> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Correspondence> Correspondences { get; set; } = null!;
        public virtual DbSet<CorrespondenceRecipient> CorrespondenceRecipients { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<Excursion> Excursions { get; set; } = null!;
        public virtual DbSet<ExcursionPoint> ExcursionPoints { get; set; } = null!;
        public virtual DbSet<Failure> Failures { get; set; } = null!;
        public virtual DbSet<FailureType> FailureTypes { get; set; } = null!;
        public virtual DbSet<Guest> Guests { get; set; } = null!;
        public virtual DbSet<Guide> Guides { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationStatus> ReservationStatuses { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomBenefit> RoomBenefits { get; set; } = null!;
        public virtual DbSet<RoomBenefit1> RoomBenefits1 { get; set; } = null!;
        public virtual DbSet<RoomEvaluation> RoomEvaluations { get; set; } = null!;
        public virtual DbSet<RoomStatus> RoomStatuses { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<RouteCategory> RouteCategories { get; set; } = null!;
        public virtual DbSet<RoutePoint> RoutePoints { get; set; } = null!;
        public virtual DbSet<TimeTable> TimeTables { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkerSchedule> WorkerSchedules { get; set; } = null!;
        public virtual DbSet<WorkerType> WorkerTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=78.60.99.137;Database=master;user id=superDuper;password=labaislaptaskodas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.HasKey(e => e.AddServicesId)
                    .HasName("PK__Addition__E581FBE1569B85BA");

                entity.HasOne(d => d.FkReservationreservation)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.FkReservationreservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hasFeatures");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasOne(d => d.FkGuestg)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.FkGuestgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pays");
            });

            modelBuilder.Entity<Correspondence>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__Correspo__0BBF6EE65F9B06F1");

                entity.HasOne(d => d.FkWorkerw)
                    .WithMany(p => p.Correspondences)
                    .HasForeignKey(d => d.FkWorkerwId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sender");
            });

            modelBuilder.Entity<CorrespondenceRecipient>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK__Correspo__810FDCE1EF5CB41A");

                entity.HasOne(d => d.FkCorrespondencemessage)
                    .WithMany(p => p.CorrespondenceRecipients)
                    .HasForeignKey(d => d.FkCorrespondencemessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Correspon__fk_Co__2665ABE1");

                entity.HasOne(d => d.FkWorkerw)
                    .WithMany(p => p.CorrespondenceRecipients)
                    .HasForeignKey(d => d.FkWorkerwId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Correspon__fk_Wo__257187A8");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                //entity.Property(e => e.DishId).ValueGeneratedNever();
                entity.Property(e => e.DishId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkAdditionalServicesaddServices)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.FkAdditionalServicesaddServicesId)
                    .HasConstraintName("included2");
            });

            modelBuilder.Entity<Excursion>(entity =>
            {
                entity.HasKey(e => e.ExId)
                    .HasName("PK__Excursio__F6D3E489E90EC2BA");

                //entity.Property(e => e.ExId).ValueGeneratedNever();
                entity.Property(e => e.ExId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkAdditionalServicesaddServices)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.FkAdditionalServicesaddServicesId)
                    .HasConstraintName("included1");
            });

            modelBuilder.Entity<ExcursionPoint>(entity =>
            {
                entity.HasKey(e => new { e.FkExcursionexId, e.FkRoutePointspointId })
                    .HasName("PK__excursio__ED529A56F4892325");

                entity.HasOne(d => d.FkExcursionex)
                    .WithMany(p => p.ExcursionPoints)
                    .HasForeignKey(d => d.FkExcursionexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("excursionPoint1");
            });

            modelBuilder.Entity<Failure>(entity =>
            {
                //entity.Property(e => e.FailureId).ValueGeneratedNever();
                entity.Property(e => e.FailureId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkFailureTypeidFailureTypeNavigation)
                    .WithMany(p => p.Failures)
                    .HasForeignKey(d => d.FkFailureTypeidFailureType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("displayType");

                entity.HasOne(d => d.FkWorkerw)
                    .WithMany(p => p.Failures)
                    .HasForeignKey(d => d.FkWorkerwId)
                    .HasConstraintName("createdFailure");
            });

            modelBuilder.Entity<FailureType>(entity =>
            {
                entity.HasKey(e => e.IdFailureType)
                    .HasName("PK__FailureT__7B28DC197C849FE0");

                entity.Property(e => e.IdFailureType).ValueGeneratedNever();
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PK__Guest__49FB61C4EC69F88A");

                entity.Property(e => e.GId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Guide>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PK__Guide__49FB61C43528AFAA");

                //entity.Property(e => e.GId).ValueGeneratedNever();
                entity.Property(e => e.GId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkExcursionex)
                    .WithMany(p => p.Guides)
                    .HasForeignKey(d => d.FkExcursionexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("responsibleGuide");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                //entity.Property(e => e.IngredientId).ValueGeneratedNever();
                entity.Property(e => e.IngredientId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkDishdish)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.FkDishdishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("containsIn");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Correspondence)
                    .HasName("PK__Message__91092B9DB1BC0E58");

                //entity.Property(e => e.Correspondence).ValueGeneratedNever();
                entity.Property(e => e.Correspondence).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkGuestg)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.FkGuestgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sendsMessage");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                //entity.Property(e => e.ReservationId).ValueGeneratedNever();
                entity.Property(e => e.ReservationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkBillbill)
                    .WithOne(p => p.Reservation)
                    .HasForeignKey<Reservation>(d => d.FkBillbillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assigns");

                entity.HasOne(d => d.FkGuestg)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkGuestgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordersReservation");

                entity.HasOne(d => d.FkReservationStatusresStatus)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkReservationStatusresStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservationStatus1");

                entity.HasOne(d => d.FkRoomidRoomNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkRoomidRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rezervedRoom");

                entity.HasOne(d => d.FkWorkerw)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkWorkerwId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("managesReservation");
            });

            modelBuilder.Entity<ReservationStatus>(entity =>
            {
                entity.HasKey(e => e.ResStatusId)
                    .HasName("PK__Reservat__375FEA2693B88057");

                //entity.Property(e => e.ResStatusId).ValueGeneratedNever();
                entity.Property(e => e.ResStatusId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK__Room__5E5ED7FBDD1E2820");

                //entity.Property(e => e.IdRoom).ValueGeneratedNever();
                entity.Property(e => e.IdRoom).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkRoomStatusroomStatug)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FkRoomStatusroomStatugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("displayes");

                entity.HasOne(d => d.FkRoomTyperoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FkRoomTyperoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("includesType");
            });

            modelBuilder.Entity<RoomBenefit>(entity =>
            {
                entity.HasKey(e => e.BenefitId)
                    .HasName("PK__RoomBene__B481E5087A25DDAA");

                entity.Property(e => e.BenefitId).ValueGeneratedOnAdd();
                //entity.Property(e => e.BenefitId).ValueGeneratedNever();
            });

            modelBuilder.Entity<RoomBenefit1>(entity =>
            {
                entity.HasKey(e => e.RoomBenefitsId)
                    .HasName("PK__RoomBene__C9B044145F1772A0");

                //entity.Property(e => e.RoomBenefitsId).ValueGeneratedNever();
                entity.Property(e => e.RoomBenefitsId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkRoomBenefitbenefit)
                    .WithMany(p => p.RoomBenefit1s)
                    .HasForeignKey(d => d.FkRoomBenefitbenefitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("benefits");

                entity.HasOne(d => d.FkRoomidRoomNavigation)
                    .WithMany(p => p.RoomBenefit1s)
                    .HasForeignKey(d => d.FkRoomidRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room1");
            });

            modelBuilder.Entity<RoomEvaluation>(entity =>
            {
                //entity.Property(e => e.RoomEvaluationId).ValueGeneratedNever();
                entity.Property(e => e.RoomEvaluationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkGuestg)
                    .WithMany(p => p.RoomEvaluations)
                    .HasForeignKey(d => d.FkGuestgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reviewUser");

                entity.HasOne(d => d.FkRoomidRoomNavigation)
                    .WithMany(p => p.RoomEvaluations)
                    .HasForeignKey(d => d.FkRoomidRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ratedRoom");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.HasKey(e => e.RoomStatugId)
                    .HasName("PK__RoomStat__9929164D3F04C259");

                //entity.Property(e => e.RoomStatugId).ValueGeneratedNever();
                entity.Property(e => e.RoomStatugId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<RouteCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__RouteCat__D54EE9B41B85FBCD");

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkRoutePointspoint)
                    .WithMany(p => p.RouteCategories)
                    .HasForeignKey(d => d.FkRoutePointspointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("includesPoints");
            });

            modelBuilder.Entity<RoutePoint>(entity =>
            {
                entity.HasKey(e => e.PointId)
                    .HasName("PK__RoutePoi__024136129DB112AD");

                entity.Property(e => e.PointId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.WId)
                    .HasName("PK__Worker__1198F2A3A6584BD6");

                entity.Property(e => e.WId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkMessageCorrespondenceNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.FkMessageCorrespondence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("senderMessage");

                entity.HasOne(d => d.FkWorkerTypeworkerType)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.FkWorkerTypeworkerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workerType");
            });

            modelBuilder.Entity<WorkerSchedule>(entity =>
            {
                entity.HasOne(d => d.FkTimeTable)
                    .WithMany(p => p.WorkerSchedules)
                    .HasForeignKey(d => d.FkTimeTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_schedule_Time_table");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
