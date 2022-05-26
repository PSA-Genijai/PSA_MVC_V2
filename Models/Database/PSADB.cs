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

        public virtual DbSet<Alergena> Alergenas { get; set; } = null!;
        public virtual DbSet<Darbuotoja> Darbuotojas { get; set; } = null!;
        public virtual DbSet<DarbuotojoTipa> DarbuotojoTipas { get; set; } = null!;
        public virtual DbSet<Ekskursija> Ekskursijas { get; set; } = null!;
        public virtual DbSet<EkskursijosPunkta> EkskursijosPunktas { get; set; } = null!;
        public virtual DbSet<Gedima> Gedimas { get; set; } = null!;
        public virtual DbSet<GedimoTipa> GedimoTipas { get; set; } = null!;
        public virtual DbSet<Gida> Gidas { get; set; } = null!;
        public virtual DbSet<KambarioIvertinima> KambarioIvertinimas { get; set; } = null!;
        public virtual DbSet<KambarioPrivaluma> KambarioPrivalumas { get; set; } = null!;
        public virtual DbSet<KambarioPrivalumai> KambarioPrivalumais { get; set; } = null!;
        public virtual DbSet<KambarioStatusa> KambarioStatusas { get; set; } = null!;
        public virtual DbSet<KambarioTipa> KambarioTipas { get; set; } = null!;
        public virtual DbSet<Kambary> Kambarys { get; set; } = null!;
        public virtual DbSet<KorespondecijaGavejai> KorespondecijaGavejais { get; set; } = null!;
        public virtual DbSet<Korespondencija> Korespondencijas { get; set; } = null!;
        public virtual DbSet<MarsrutoPunktai> MarsrutoPunktais { get; set; } = null!;
        public virtual DbSet<PapildomosPaslaugo> PapildomosPaslaugos { get; set; } = null!;
        public virtual DbSet<Patiekala> Patiekalas { get; set; } = null!;
        public virtual DbSet<Pranesima> Pranesimas { get; set; } = null!;
        public virtual DbSet<PunktuKategorijo> PunktuKategorijos { get; set; } = null!;
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; } = null!;
        public virtual DbSet<RezervacijosStatusa> RezervacijosStatusas { get; set; } = null!;
        public virtual DbSet<Saskaitum> Saskaita { get; set; } = null!;
        public virtual DbSet<Svecia> Svecias { get; set; } = null!;

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
            modelBuilder.Entity<Alergena>(entity =>
            {
                entity.HasKey(e => e.AlergenasId)
                    .HasName("PK__Alergena__C4642F98F8B71D8B");

                entity.Property(e => e.AlergenasId).ValueGeneratedNever();

                entity.HasOne(d => d.FkPatiekalaspatiekalas)
                    .WithMany(p => p.Alergenas)
                    .HasForeignKey(d => d.FkPatiekalaspatiekalasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurodyti");
            });

            modelBuilder.Entity<Darbuotoja>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__Darbuoto__D95F582BFDB3D52A");

                entity.Property(e => e.DId).ValueGeneratedNever();

                entity.HasOne(d => d.FkDarbuotojoTipasdarbTipas)
                    .WithMany(p => p.Darbuotojas)
                    .HasForeignKey(d => d.FkDarbuotojoTipasdarbTipasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurodoTipa");

                entity.HasOne(d => d.FkPranesimaspranesimas)
                    .WithMany(p => p.Darbuotojas)
                    .HasForeignKey(d => d.FkPranesimaspranesimasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atsisiunciaPranesima");
            });

            modelBuilder.Entity<DarbuotojoTipa>(entity =>
            {
                entity.HasKey(e => e.DarbTipasId)
                    .HasName("PK__Darbuoto__FF76D8316E909308");

                entity.Property(e => e.DarbTipasId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ekskursija>(entity =>
            {
                entity.HasKey(e => e.EksId)
                    .HasName("PK__Ekskursi__A8CA98727F255A39");

                entity.Property(e => e.EksId).ValueGeneratedNever();

                entity.HasOne(d => d.FkPapildomosPaslaugospapPaslaugos)
                    .WithMany(p => p.Ekskursijas)
                    .HasForeignKey(d => d.FkPapildomosPaslaugospapPaslaugosId)
                    .HasConstraintName("itrauktos");
            });

            modelBuilder.Entity<EkskursijosPunkta>(entity =>
            {
                entity.HasKey(e => new { e.FkEkskursijaeksId, e.FkMarsrutoPunktaipunktoId })
                    .HasName("PK__ekskursi__3C36437BF8207CFA");

                entity.HasOne(d => d.FkEkskursijaeks)
                    .WithMany(p => p.EkskursijosPunkta)
                    .HasForeignKey(d => d.FkEkskursijaeksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ekskursijosPunktas1");
            });

            modelBuilder.Entity<Gedima>(entity =>
            {
                entity.HasKey(e => e.GedimasId)
                    .HasName("PK__Gedimas__FC4D7570CCA7D1F8");

                entity.Property(e => e.GedimasId).ValueGeneratedNever();

                entity.HasOne(d => d.FkDarbuotojasd)
                    .WithMany(p => p.Gedimas)
                    .HasForeignKey(d => d.FkDarbuotojasdId)
                    .HasConstraintName("sukuriaGedima");

                entity.HasOne(d => d.FkGedimoTipasidGedimoTipasNavigation)
                    .WithMany(p => p.Gedimas)
                    .HasForeignKey(d => d.FkGedimoTipasidGedimoTipas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parodoTipa");
            });

            modelBuilder.Entity<GedimoTipa>(entity =>
            {
                entity.HasKey(e => e.IdGedimoTipas)
                    .HasName("PK__GedimoTi__9A20E925D4E56154");

                entity.Property(e => e.IdGedimoTipas).ValueGeneratedNever();
            });

            modelBuilder.Entity<Gida>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PK__Gidas__49FB61C48CC41661");

                entity.Property(e => e.GId).ValueGeneratedNever();

                entity.HasOne(d => d.FkEkskursijaeks)
                    .WithMany(p => p.Gida)
                    .HasForeignKey(d => d.FkEkskursijaeksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("veda");
            });

            modelBuilder.Entity<KambarioIvertinima>(entity =>
            {
                entity.HasKey(e => e.KambIvertinimasId)
                    .HasName("PK__Kambario__270302948B1CCC60");

                entity.Property(e => e.KambIvertinimasId).ValueGeneratedNever();

                entity.HasOne(d => d.FkKambarysidKambarysNavigation)
                    .WithMany(p => p.KambarioIvertinimas)
                    .HasForeignKey(d => d.FkKambarysidKambarys)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ivertina");

                entity.HasOne(d => d.FkSveciass)
                    .WithMany(p => p.KambarioIvertinimas)
                    .HasForeignKey(d => d.FkSveciassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("apraso");
            });

            modelBuilder.Entity<KambarioPrivaluma>(entity =>
            {
                entity.HasKey(e => e.PrivalumasId)
                    .HasName("PK__Kambario__AA2B248E2B7371C9");

                entity.Property(e => e.PrivalumasId).ValueGeneratedNever();
            });

            modelBuilder.Entity<KambarioPrivalumai>(entity =>
            {
                entity.HasKey(e => e.KambPrivalumaiId)
                    .HasName("PK__Kambario__585408EF2BA6090D");

                entity.Property(e => e.KambPrivalumaiId).ValueGeneratedNever();

                entity.HasOne(d => d.FkKambarioPrivalumasprivalumas)
                    .WithMany(p => p.KambarioPrivalumais)
                    .HasForeignKey(d => d.FkKambarioPrivalumasprivalumasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turiPrivalumus");

                entity.HasOne(d => d.FkKambarysidKambarysNavigation)
                    .WithMany(p => p.KambarioPrivalumais)
                    .HasForeignKey(d => d.FkKambarysidKambarys)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priskiriami");
            });

            modelBuilder.Entity<KambarioStatusa>(entity =>
            {
                entity.HasKey(e => e.KambStatusasId)
                    .HasName("PK__Kambario__AF2BC7159AE37C1E");

                entity.Property(e => e.KambStatusasId).ValueGeneratedNever();
            });

            modelBuilder.Entity<KambarioTipa>(entity =>
            {
                entity.HasKey(e => e.KambTipasId)
                    .HasName("PK__Kambario__C4CDD5585B1A0B2B");

                entity.Property(e => e.KambTipasId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Kambary>(entity =>
            {
                entity.HasKey(e => e.IdKambarys)
                    .HasName("PK__Kambarys__27DA93E240DE345A");

                entity.Property(e => e.IdKambarys).ValueGeneratedNever();

                entity.HasOne(d => d.FkKambarioStatusaskambStatusas)
                    .WithMany(p => p.Kambaries)
                    .HasForeignKey(d => d.FkKambarioStatusaskambStatusasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurodoma");

                entity.HasOne(d => d.FkKambarioTipaskambTipas)
                    .WithMany(p => p.Kambaries)
                    .HasForeignKey(d => d.FkKambarioTipaskambTipasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priskiriama");
            });

            modelBuilder.Entity<KorespondecijaGavejai>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK__Korespon__810FDCE19CDC1C5D");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.HasOne(d => d.FkDarbuotojasd)
                    .WithMany(p => p.KorespondecijaGavejais)
                    .HasForeignKey(d => d.FkDarbuotojasdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korespond__fk_Da__5B0E7E4A");

                entity.HasOne(d => d.FkKorespondencijazinute)
                    .WithMany(p => p.KorespondecijaGavejais)
                    .HasForeignKey(d => d.FkKorespondencijazinuteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korespond__fk_Ko__5C02A283");
            });

            modelBuilder.Entity<Korespondencija>(entity =>
            {
                entity.HasKey(e => e.ZinuteId)
                    .HasName("PK__Korespon__B791943390F213B2");

                entity.Property(e => e.ZinuteId).ValueGeneratedNever();

                entity.HasOne(d => d.FkDarbuotojasd)
                    .WithMany(p => p.Korespondencijas)
                    .HasForeignKey(d => d.FkDarbuotojasdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("siuntejas");
            });

            modelBuilder.Entity<MarsrutoPunktai>(entity =>
            {
                entity.HasKey(e => e.PunktoId)
                    .HasName("PK__Marsruto__E44273F3919D4752");

                entity.Property(e => e.PunktoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PapildomosPaslaugo>(entity =>
            {
                entity.HasKey(e => e.PapPaslaugosId)
                    .HasName("PK__Papildom__F11097094F5B0440");

                entity.Property(e => e.PapPaslaugosId).ValueGeneratedNever();

                entity.HasOne(d => d.FkRezervacijarezervacija)
                    .WithMany(p => p.PapildomosPaslaugos)
                    .HasForeignKey(d => d.FkRezervacijarezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turiPaslaugas");
            });

            modelBuilder.Entity<Patiekala>(entity =>
            {
                entity.HasKey(e => e.PatiekalasId)
                    .HasName("PK__Patiekal__0C0E1A00E4831D61");

                entity.Property(e => e.PatiekalasId).ValueGeneratedNever();

                entity.HasOne(d => d.FkPapildomosPaslaugospapPaslaugos)
                    .WithMany(p => p.Patiekalas)
                    .HasForeignKey(d => d.FkPapildomosPaslaugospapPaslaugosId)
                    .HasConstraintName("itraukti");
            });

            modelBuilder.Entity<Pranesima>(entity =>
            {
                entity.HasKey(e => e.PranesimasId)
                    .HasName("PK__Pranesim__A9F8922B046F447B");

                entity.Property(e => e.PranesimasId).ValueGeneratedNever();

                entity.HasOne(d => d.FkSveciass)
                    .WithMany(p => p.Pranesimas)
                    .HasForeignKey(d => d.FkSveciassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("issiunciaPranesima");
            });

            modelBuilder.Entity<PunktuKategorijo>(entity =>
            {
                entity.HasKey(e => e.KategorijosId)
                    .HasName("PK__PunktuKa__83E43221531B58B7");

                entity.Property(e => e.KategorijosId).ValueGeneratedNever();

                entity.HasOne(d => d.FkMarsrutoPunktaipunkto)
                    .WithMany(p => p.PunktuKategorijos)
                    .HasForeignKey(d => d.FkMarsrutoPunktaipunktoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.Property(e => e.RezervacijaId).ValueGeneratedNever();

                entity.HasOne(d => d.FkDarbuotojasd)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.FkDarbuotojasdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priziuriRezervacijas");

                entity.HasOne(d => d.FkKambarysidKambarysNavigation)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.FkKambarysidKambarys)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rezervuotasKambarys");

                entity.HasOne(d => d.FkRezervacijosStatusasrezStatusas)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.FkRezervacijosStatusasrezStatusasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurodoStatusa");

                entity.HasOne(d => d.FkSaskaitasaskaita)
                    .WithOne(p => p.Rezervacija)
                    .HasForeignKey<Rezervacija>(d => d.FkSaskaitasaskaitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priskirta");

                entity.HasOne(d => d.FkSveciass)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.FkSveciassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sukuriaRegistracija");
            });

            modelBuilder.Entity<RezervacijosStatusa>(entity =>
            {
                entity.HasKey(e => e.RezStatusasId)
                    .HasName("PK__Rezervac__9A0C0F26A0EF8122");

                entity.Property(e => e.RezStatusasId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Saskaitum>(entity =>
            {
                entity.HasKey(e => e.SaskaitaId)
                    .HasName("PK__Saskaita__2EB32554BA1829AE");

                entity.Property(e => e.SaskaitaId).ValueGeneratedNever();

                entity.HasOne(d => d.FkSveciass)
                    .WithMany(p => p.Saskaita)
                    .HasForeignKey(d => d.FkSveciassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("apmoka");
            });

            modelBuilder.Entity<Svecia>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__Svecias__2F3684F42D4137F9");

                entity.Property(e => e.SId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
