using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pf_maestros.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<SchemaVersion> SchemaVersion { get; set; }
        public virtual DbSet<TpfAdquirentes> TpfAdquirentes { get; set; }
        public virtual DbSet<TpfDocHabilitacion> TpfDocHabilitacion { get; set; }
        public virtual DbSet<TpfDocumentos> TpfDocumentos { get; set; }
        public virtual DbSet<TpfEmisores> TpfEmisores { get; set; }
        public virtual DbSet<TpfEmisorxgrupo> TpfEmisorxgrupo { get; set; }
        public virtual DbSet<TpfGruposEmisores> TpfGruposEmisores { get; set; }
        public virtual DbSet<TpfPersonas> TpfPersonas { get; set; }
        public virtual DbSet<TpfPlanes> TpfPlanes { get; set; }
        public virtual DbSet<TpfProductos> TpfProductos { get; set; }
        public virtual DbSet<TpfRecargas> TpfRecargas { get; set; }
        public virtual DbSet<TpfResolucionEmisor> TpfResolucionEmisor { get; set; }
        public virtual DbSet<TpfSaldos> TpfSaldos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchemaVersion>(entity =>
            {
                entity.HasKey(e => e.InstalledRank);

                entity.ToTable("schema_version");

                entity.HasIndex(e => e.Success)
                    .HasName("schema_version_s_idx");

                entity.Property(e => e.InstalledRank)
                    .HasColumnName("installed_rank")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Checksum)
                    .HasColumnName("checksum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutionTime)
                    .HasColumnName("execution_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstalledBy)
                    .IsRequired()
                    .HasColumnName("installed_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstalledOn)
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Success)
                    .HasColumnName("success")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TpfAdquirentes>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_ADQUIRENTES");

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISOR_ADQUIRENTE_idx");

                entity.HasIndex(e => new { e.NmIdEmisor, e.CdTipoIdentificacion, e.DsIdentificacion })
                    .HasName("UNIQ_EMI_TIPOIDEN_IDENT")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdAdqResponsable)
                    .IsRequired()
                    .HasColumnName("CD_ADQ_RESPONSABLE")
                    .HasColumnType("set('1','0')");

                entity.Property(e => e.CdCiudad)
                    .IsRequired()
                    .HasColumnName("CD_CIUDAD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CdEstado)
                    .IsRequired()
                    .HasColumnName("CD_ESTADO")
                    .HasColumnType("set('A','I')")
                    .HasDefaultValueSql("A");

                entity.Property(e => e.CdTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("CD_TIPO_IDENTIFICACION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdTipoPersona)
                    .IsRequired()
                    .HasColumnName("CD_TIPO_PERSONA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DsDigitoVerif)
                    .IsRequired()
                    .HasColumnName("DS_DIGITO_VERIF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DsDireccion)
                    .IsRequired()
                    .HasColumnName("DS_DIRECCION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsIdentificacion)
                    .IsRequired()
                    .HasColumnName("DS_IDENTIFICACION")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DsNombre)
                    .IsRequired()
                    .HasColumnName("DS_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsPrimerApellido)
                    .HasColumnName("DS_PRIMER_APELLIDO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsSegundoApellido)
                    .HasColumnName("DS_SEGUNDO_APELLIDO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsSegundoNombre)
                    .HasColumnName("DS_SEGUNDO_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsTelefono)
                    .IsRequired()
                    .HasColumnName("DS_TELEFONO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmRegimen)
                    .IsRequired()
                    .HasColumnName("NM_REGIMEN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmResponFiscales)
                    .IsRequired()
                    .HasColumnName("NM_RESPON_FISCALES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfAdquirentes)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISOR_ADQUIRENTE");
            });

            modelBuilder.Entity<TpfDocHabilitacion>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_DOC_HABILITACION");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DsJsonDocumento)
                    .IsRequired()
                    .HasColumnName("DS_JSON_DOCUMENTO")
                    .HasColumnType("json");

                entity.Property(e => e.DsNumDoc)
                    .HasColumnName("DS_NUM_DOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsPrefijoDoc)
                    .HasColumnName("DS_PREFIJO_DOC")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DsTipoDoc)
                    .HasColumnName("DS_TIPO_DOC")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TpfDocumentos>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_DOCUMENTOS");

                entity.HasIndex(e => e.DsPin)
                    .HasName("IX_DS_PIN");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISOR_DOC_idx");

                entity.HasIndex(e => new { e.NmIdEmisor, e.DsNumDoc, e.DsPrefijoDoc, e.DsTipoDoc })
                    .HasName("UQ_EMI_ADQ_FACT")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdEstado)
                    .HasColumnName("CD_ESTADO")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CdEstadoPin)
                    .HasColumnName("CD_ESTADO_PIN")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CdVersion)
                    .IsRequired()
                    .HasColumnName("CD_VERSION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DsIdAquirente)
                    .HasColumnName("DS_ID_AQUIRENTE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DsJsonDocumento)
                    .IsRequired()
                    .HasColumnName("DS_JSON_DOCUMENTO")
                    .HasColumnType("json");

                entity.Property(e => e.DsNumDoc)
                    .IsRequired()
                    .HasColumnName("DS_NUM_DOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsPin)
                    .HasColumnName("DS_PIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsPrefijoDoc)
                    .HasColumnName("DS_PREFIJO_DOC")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DsResponse)
                    .HasColumnName("DS_RESPONSE")
                    .HasMaxLength(20000)
                    .IsUnicode(false);

                entity.Property(e => e.DsTipoDoc)
                    .IsRequired()
                    .HasColumnName("DS_TIPO_DOC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DsUsuarioConcilia)
                    .HasColumnName("DS_USUARIO_CONCILIA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeEstadoPin)
                    .HasColumnName("FE_ESTADO_PIN")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeFactura)
                    .HasColumnName("FE_FACTURA")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeModifica)
                    .HasColumnName("FE_MODIFICA")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfDocumentos)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISOR_DOC");
            });

            modelBuilder.Entity<TpfEmisores>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_EMISORES");

                entity.HasIndex(e => e.NmId)
                    .HasName("IXFK_TPF_EMISORES");

                entity.HasIndex(e => e.NmIdPersona)
                    .HasName("FK_PERSONA_ID_idx");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdGrupo)
                    .HasColumnName("CD_GRUPO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdHabilitado)
                    .HasColumnName("CD_HABILITADO")
                    .HasColumnType("set('S','N')")
                    .HasDefaultValueSql("N");

                entity.Property(e => e.CdRetenedorImpuestos)
                    .HasColumnName("CD_RETENEDOR_IMPUESTOS")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CdTipoPersona)
                    .IsRequired()
                    .HasColumnName("CD_TIPO_PERSONA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdTipoRegimen)
                    .HasColumnName("CD_TIPO_REGIMEN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdVersion)
                    .IsRequired()
                    .HasColumnName("CD_VERSION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DsEmailRemitente)
                    .IsRequired()
                    .HasColumnName("DS_EMAIL_REMITENTE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsLogo)
                    .IsRequired()
                    .HasColumnName("DS_LOGO")
                    .IsUnicode(false);

                entity.Property(e => e.DsObservacion)
                    .HasColumnName("DS_OBSERVACION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DsPiePagina)
                    .HasColumnName("DS_PIE_PAGINA")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DsTokenSeguridad)
                    .HasColumnName("DS_TOKEN_SEGURIDAD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdPersona)
                    .HasColumnName("NM_ID_PERSONA")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdPersonaNavigation)
                    .WithMany(p => p.TpfEmisores)
                    .HasForeignKey(d => d.NmIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSONAS_ID");
            });

            modelBuilder.Entity<TpfEmisorxgrupo>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_EMISORXGRUPO");

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISORES_GRUP_idx");

                entity.HasIndex(e => e.NmIdGrupo)
                    .HasName("FK_GRUPO_GRUP_idx");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmIdGrupo)
                    .HasColumnName("NM_ID_GRUPO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfEmisorxgrupo)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISORES_GRUP");

                entity.HasOne(d => d.NmIdGrupoNavigation)
                    .WithMany(p => p.TpfEmisorxgrupo)
                    .HasForeignKey(d => d.NmIdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRUPO_GRUP");
            });

            modelBuilder.Entity<TpfGruposEmisores>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_GRUPOS_EMISORES");

                entity.HasIndex(e => e.DsNombreGrupo)
                    .HasName("DS_NOMBRE_IX");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DsNombreGrupo)
                    .IsRequired()
                    .HasColumnName("DS_NOMBRE_GRUPO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<TpfPersonas>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_PERSONAS");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdCiudad)
                    .IsRequired()
                    .HasColumnName("CD_CIUDAD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CdTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("CD_TIPO_IDENTIFICACION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DsCelular)
                    .HasColumnName("DS_CELULAR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsDireccion)
                    .HasColumnName("DS_DIRECCION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsIdentificacion)
                    .IsRequired()
                    .HasColumnName("DS_IDENTIFICACION")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DsNombre)
                    .IsRequired()
                    .HasColumnName("DS_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsPrimerApellido)
                    .HasColumnName("DS_PRIMER_APELLIDO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsSegundoApellido)
                    .HasColumnName("DS_SEGUNDO_APELLIDO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsSegundoNombre)
                    .HasColumnName("DS_SEGUNDO_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsTelefono)
                    .HasColumnName("DS_TELEFONO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsTokenPrimrecar)
                    .HasColumnName("DS_TOKEN_PRIMRECAR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<TpfPlanes>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_PLANES");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdEstado)
                    .HasColumnName("CD_ESTADO")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CdVisible)
                    .HasColumnName("CD_VISIBLE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("N");

                entity.Property(e => e.DsDescripcion)
                    .HasColumnName("DS_DESCRIPCION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmCantDoc)
                    .HasColumnName("NM_CANT_DOC")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmDocRegalo)
                    .HasColumnName("NM_DOC_REGALO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmValor)
                    .HasColumnName("NM_VALOR")
                    .HasColumnType("float(11,3)");
            });

            modelBuilder.Entity<TpfProductos>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_PRODUCTOS");

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISORES_ID_idx");

                entity.HasIndex(e => new { e.NmIdEmisor, e.DsCodigo })
                    .HasName("UNIQ_PRODUC_EMI_COD")
                    .IsUnique();

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdEstado)
                    .IsRequired()
                    .HasColumnName("CD_ESTADO")
                    .HasColumnType("set('A','I')")
                    .HasDefaultValueSql("A");

                entity.Property(e => e.DsCodigo)
                    .IsRequired()
                    .HasColumnName("DS_CODIGO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DsDescripcion)
                    .IsRequired()
                    .HasColumnName("DS_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmMarca)
                    .HasColumnName("NM_MARCA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmModelo)
                    .HasColumnName("NM_MODELO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmPorcentajeInc)
                    .HasColumnName("NM_PORCENTAJE_INC")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmPorcentajeIva)
                    .HasColumnName("NM_PORCENTAJE_IVA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmUnidadMedida)
                    .IsRequired()
                    .HasColumnName("NM_UNIDAD_MEDIDA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmValorUnitario)
                    .HasColumnName("NM_VALOR_UNITARIO")
                    .HasColumnType("decimal(13,2)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfProductos)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISORES_ID");
            });

            modelBuilder.Entity<TpfRecargas>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_RECARGAS");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISOR_RECARG_idx");

                entity.HasIndex(e => e.NmIdPlan)
                    .HasName("FK_PLAN_RECARG_idx");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmIdPlan)
                    .HasColumnName("NM_ID_PLAN")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfRecargas)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISOR_RECARG");

                entity.HasOne(d => d.NmIdPlanNavigation)
                    .WithMany(p => p.TpfRecargas)
                    .HasForeignKey(d => d.NmIdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAN_RECARG");
            });

            modelBuilder.Entity<TpfResolucionEmisor>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_RESOLUCION_EMISOR");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISOR_RANGO_idx");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdEstado)
                    .IsRequired()
                    .HasColumnName("CD_ESTADO")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DsPrefijo)
                    .HasColumnName("DS_PREFIJO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DsResolucionDian)
                    .IsRequired()
                    .HasColumnName("DS_RESOLUCION_DIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeVencimiento).HasColumnName("FE_VENCIMIENTO");

                entity.Property(e => e.NmFin)
                    .HasColumnName("NM_FIN")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmInicio)
                    .HasColumnName("NM_INICIO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfResolucionEmisor)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISOR_RESOLUCION");
            });

            modelBuilder.Entity<TpfSaldos>(entity =>
            {
                entity.HasKey(e => e.NmId);

                entity.ToTable("TPF_SALDOS");

                entity.HasIndex(e => e.NmId)
                    .HasName("NM_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NmIdEmisor)
                    .HasName("FK_EMISOR_SALDO_idx");

                entity.Property(e => e.NmId)
                    .HasColumnName("NM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeProceso)
                    .HasColumnName("FE_PROCESO")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NmIdEmisor)
                    .HasColumnName("NM_ID_EMISOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NmSaldo)
                    .HasColumnName("NM_SALDO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NmIdEmisorNavigation)
                    .WithMany(p => p.TpfSaldos)
                    .HasForeignKey(d => d.NmIdEmisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMISOR_SALDO");
            });
        }
    }
}
