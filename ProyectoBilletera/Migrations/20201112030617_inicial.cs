using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clip.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    idFactura = table.Column<int>(type: "int", nullable: false),
                    fechaElaboracion = table.Column<DateTime>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    fechaVencimiento = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.idFactura);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    idProvincia = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idProvincia);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Inversion",
                columns: table => new
                {
                    idTipoInversion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    tasa = table.Column<decimal>(type: "numeric(2,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Inversion", x => x.idTipoInversion);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Moneda",
                columns: table => new
                {
                    idTipoMoneda = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Moneda", x => x.idTipoMoneda);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Operacion",
                columns: table => new
                {
                    idTipoOperacion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    tasa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Operacion", x => x.idTipoOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Servicio",
                columns: table => new
                {
                    idTipoServicio = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Servicio", x => x.idTipoServicio);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    idLocalidad = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    idProvincia = table.Column<int>(type: "int", nullable: true),
                    codigoPostal = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.idLocalidad);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia",
                        column: x => x.idProvincia,
                        principalTable: "Provincia",
                        principalColumn: "idProvincia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    idServicio = table.Column<int>(type: "int", nullable: false),
                    idTipoServicio = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    descripcion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.idServicio);
                    table.ForeignKey(
                        name: "FK_Servicio_Tipo_Servicio",
                        column: x => x.idServicio,
                        principalTable: "Tipo_Servicio",
                        principalColumn: "idTipoServicio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    idDireccion = table.Column<int>(type: "int", nullable: false),
                    calle = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    numero = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    idLocalidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.idDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Localidad",
                        column: x => x.idLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "idLocalidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    idDetalleFactura = table.Column<int>(type: "int", nullable: false),
                    idFactura = table.Column<int>(type: "int", nullable: true),
                    idServicio = table.Column<int>(type: "int", nullable: true),
                    subTotal = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.idDetalleFactura);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Factura",
                        column: x => x.idDetalleFactura,
                        principalTable: "Factura",
                        principalColumn: "idFactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Servicio",
                        column: x => x.idServicio,
                        principalTable: "Servicio",
                        principalColumn: "idServicio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    idDireccion = table.Column<int>(type: "int", nullable: true),
                    cvu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nroTelefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nroDNI = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    frontalDNI = table.Column<byte[]>(type: "image", nullable: true),
                    traseraDNI = table.Column<byte[]>(type: "image", nullable: true),
                    email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Direccion",
                        column: x => x.idDireccion,
                        principalTable: "Direccion",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entidad_Bancaria",
                columns: table => new
                {
                    idEntidadBancaria = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    idDireccion = table.Column<int>(type: "int", nullable: true),
                    razonSocial = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad_Bancaria", x => x.idEntidadBancaria);
                    table.ForeignKey(
                        name: "FK_Entidad_Bancaria_Direccion",
                        column: x => x.idEntidadBancaria,
                        principalTable: "Direccion",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    nombreUsuario = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false),
                    idEntidadBancaria = table.Column<int>(type: "int", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    idTipoMoneda = table.Column<int>(type: "int", nullable: true),
                    cvu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    saldo = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    topeDescubierto = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.idCuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cuenta_Entidad_Bancaria",
                        column: x => x.idEntidadBancaria,
                        principalTable: "Entidad_Bancaria",
                        principalColumn: "idEntidadBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cuenta_Tipo_Moneda",
                        column: x => x.idTipoMoneda,
                        principalTable: "Tipo_Moneda",
                        principalColumn: "idTipoMoneda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inversion",
                columns: table => new
                {
                    idInversion = table.Column<int>(type: "int", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: true),
                    idTipoInversion = table.Column<int>(type: "int", nullable: true),
                    fechaInicio = table.Column<DateTime>(type: "date", nullable: true),
                    cantidadDias = table.Column<int>(type: "int", nullable: true),
                    montoInicial = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inversion", x => x.idInversion);
                    table.ForeignKey(
                        name: "FK_Inversion_Cuenta",
                        column: x => x.idCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inversion_Tipo_Inversion",
                        column: x => x.idInversion,
                        principalTable: "Tipo_Inversion",
                        principalColumn: "idTipoInversion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false),
                    idTipoOperacion = table.Column<int>(type: "int", nullable: true),
                    idCuenta = table.Column<int>(type: "int", nullable: true),
                    nroOperacion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    estado = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    fechaOperacion = table.Column<DateTime>(type: "date", nullable: true),
                    horaOperacion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    monto = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.idOperacion);
                    table.ForeignKey(
                        name: "FK_Operacion_Cuenta",
                        column: x => x.idCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacion_Tipo_Operacion",
                        column: x => x.idOperacion,
                        principalTable: "Tipo_Operacion",
                        principalColumn: "idTipoOperacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: true),
                    idFactura = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    cantCuotas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.idPago);
                    table.ForeignKey(
                        name: "FK_Pago_Cuenta",
                        column: x => x.idCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pago_Factura",
                        column: x => x.idFactura,
                        principalTable: "Factura",
                        principalColumn: "idFactura",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    idTransferencia = table.Column<int>(type: "int", nullable: false),
                    idCuentaOrigen = table.Column<int>(type: "int", nullable: true),
                    idCuentaDestino = table.Column<int>(type: "int", nullable: true),
                    monto = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    fechaOperacion = table.Column<DateTime>(type: "date", nullable: true),
                    horaOperacion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    motivo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.idTransferencia);
                    table.ForeignKey(
                        name: "FK_Transferencia_CuentaDestino",
                        column: x => x.idCuentaDestino,
                        principalTable: "Cuenta",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencia_CuentaOrigin",
                        column: x => x.idCuentaOrigen,
                        principalTable: "Cuenta",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idDireccion",
                table: "Cliente",
                column: "idDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_idCliente",
                table: "Cuenta",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_idEntidadBancaria",
                table: "Cuenta",
                column: "idEntidadBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_idTipoMoneda",
                table: "Cuenta",
                column: "idTipoMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_idServicio",
                table: "DetalleFactura",
                column: "idServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_idLocalidad",
                table: "Direccion",
                column: "idLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Inversion_idCuenta",
                table: "Inversion",
                column: "idCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_idProvincia",
                table: "Localidad",
                column: "idProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_idCuenta",
                table: "Operacion",
                column: "idCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_idCuenta",
                table: "Pago",
                column: "idCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_idFactura",
                table: "Pago",
                column: "idFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_idCuentaDestino",
                table: "Transferencia",
                column: "idCuentaDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_idCuentaOrigen",
                table: "Transferencia",
                column: "idCuentaOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idCliente",
                table: "Usuario",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Inversion");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Tipo_Inversion");

            migrationBuilder.DropTable(
                name: "Tipo_Operacion");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Tipo_Servicio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Entidad_Bancaria");

            migrationBuilder.DropTable(
                name: "Tipo_Moneda");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
