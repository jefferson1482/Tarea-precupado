using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_preocupado
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Tarea 1");
            // Numeros al azar
            Console.WriteLine("{Creando numeros aleatorios}");
            Random azar = new Random();
            List<int> numero = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                numero.Add(azar.Next(40, 60));
            }
            numero.ForEach(j => Console.WriteLine(j));

            // Numeros primos 
            Console.WriteLine("{Numeros Primos}");
            var pri = from p in numero select p;
            foreach (var item3 in pri)
            {
                if (item3 % 2 != 0)
                {
                    Console.WriteLine(item3);
                }
            }

            // Suma de numeros
            Console.WriteLine("{Suma de todos los elementos}");
            int acu = 0;
            numero.ForEach(x =>
            {
                acu = acu + x;
            }
            );
            Console.WriteLine(acu);

            // Cuadrado de los numeros
            Console.WriteLine("{Cuadrado de los numeros}");
            int c = 0;
            var cuadrado = from B in numero where B >= 0 select B;
            foreach (var item in cuadrado)
            {
                c = item * item;
                Console.WriteLine(c);
            }

            // Lista de numeros primos 
            Console.WriteLine("{Lista de numeros primos}");
            (from lu in pri select lu).ToList().ForEach(LU => 
            {
                if (LU % 2 !=0)
                {
                    Console.WriteLine(LU);
                }
            });
        
            // Numeros mayores a 50
            Console.WriteLine("{Numeros mayores a 50 son}");
            int co = 0, di = 0, can = 0;
            var promedio = from M in numero where M >= 50 select M;
            foreach (var item in promedio)
            {
                Console.WriteLine(item);
                co = co + item;
                can++;
            }
            di = co / can;
            Console.WriteLine("promedio");
            Console.WriteLine(di);

            //Numeros Pares e Impares
            Console.WriteLine("{Numeros pares e impares}");
            int CP = 0, CI = 0;
            var PI = from pi in numero select pi;
            Console.WriteLine("\tLos numeros impares son:");
            foreach (var item in PI)
            {
                if (item % 2 != 0)
                {

                    Console.WriteLine(item);
                    CI++;
                }
            }
            Console.WriteLine("La cantidad de numero de impares son:");
            Console.WriteLine(CI);
            Console.WriteLine("\tLos numeros pares son:");
            foreach (var tem in PI)
            {
                if (tem % 2 == 0)
                {
                    Console.WriteLine(tem);
                    CP++;
                }
            }
            Console.WriteLine("La cantidad de numero pares son:");
            Console.WriteLine(CP);

            //Cantidad de veces que se encuentre en la lista

            //Forma desendente
            Console.WriteLine("{Numeros en forma desendente}");
            var desen = from D in numero orderby D descending select D;
            foreach (var item in desen)
            {
                Console.WriteLine(item);
            }

            //Numeros Unicos
            Console.WriteLine("{Numeros unicos en un lista y suma}");
            int cont = 0, sumar = 0;
            numero.ForEach(uni =>
            {
                foreach (var item in numero)
                {
                    if (item == uni)
                    {
                        cont++;
                    }
                }
                if (cont == 1)
                {
                    sumar = sumar + uni;
                    Console.WriteLine("Numeros unicos={0}, suma={1}",uni,sumar);
                }
            });

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.WriteLine("Tarea 2");

            List<Cliente> listacliente = new List<Cliente>()
            {
                new Cliente(){Id = 1,Nombres = "Jefferson"},
                new Cliente(){Id = 2,Nombres = "Isleny"},
                new Cliente(){Id = 3,Nombres = "Carolane"},
                new Cliente(){Id = 4,Nombres = "Angie"},
                new Cliente(){Id = 5,Nombres = "Carolina"},
                new Cliente(){Id = 6,Nombres = "Joselin"},
                new Cliente(){Id = 7,Nombres = "Alexandra"},
                new Cliente(){Id = 8,Nombres = "Jordy"},
                new Cliente(){Id = 9,Nombres = "Rick"},
                new Cliente(){Id = 10,Nombres = "Ronny"}
            };

            List<Factura> listafactura = new List<Factura>()
            {
                new Factura(){Id = 1,IdCliente = 3,Observacion = "Ropa",Fecha = new DateTime(2018,1,12),Total = 12},
                new Factura(){Id = 2,IdCliente = 1,Observacion = "Consolas",Fecha = new DateTime(2019,12,23),Total = 13},
                new Factura(){Id = 3,IdCliente = 5,Observacion = "Comida",Fecha = new DateTime(2016,9,13),Total = 14},
                new Factura(){Id = 4,IdCliente = 4,Observacion = "Viajes",Fecha = new DateTime(2015,10,30),Total = 15},
                new Factura(){Id = 5,IdCliente = 6,Observacion = "Gordo",Fecha = new DateTime(2018,12,6),Total = 10},
                new Factura(){Id = 6,IdCliente = 7,Observacion = "Flaco",Fecha = new DateTime(2015,12,5),Total = 9},
                new Factura(){Id = 7,IdCliente = 8,Observacion = "Prob",Fecha = new DateTime(2013,12,4),Total = 8},
                new Factura(){Id = 8,IdCliente = 9,Observacion = "Romantica",Fecha = new DateTime(2019,12,3),Total = 7},
                new Factura(){Id = 9,IdCliente = 10,Observacion = "flaco",Fecha = new DateTime(2011,11,2),Total = 6},
                new Factura(){Id = 10,IdCliente = 2,Observacion = "Maquillaje",Fecha = new DateTime(2019,12,10),Total = 18}
            };

            //Orden de los clientes  
            Console.WriteLine("{Orden de los clientes}");
            var ordencliente = from o in listacliente orderby o.Nombres select o;
            foreach (var item in ordencliente)
            {
                Console.WriteLine(item.Nombres);
            }

            // Orden por fecha 
            Console.WriteLine("\n{Orden por fecha}");
            var ordenfecha = from m in listafactura orderby m.Fecha select m;
            foreach (var item in ordenfecha)
            {
                Console.WriteLine(item.Fecha);
            }

            // CLiente con mas venta realizada
            Console.WriteLine("\n{Cliente con mas cantidad de venta}");
            var clientemayorventa = from CM in listafactura
                                    join cm in listacliente on CM.IdCliente equals cm.Id
                                    select new {dventa = CM.Total,
                                    dcliente = cm.Nombres
                                    };
            int acumulador = 0;
            foreach (var item in clientemayorventa)
            {
                if (item.dventa > acumulador)
                {
                    acumulador = item.dventa;
                }
                if (acumulador > 16)
                {
                    Console.WriteLine("{0} = {1}", item.dcliente, acumulador);             
                }
            }

            //Cliente y cantidad de venta 
            Console.WriteLine("\n{Cliente y cantidad de venta}");
            var clienteventa = from j in listafactura
                               join l in listacliente on j.IdCliente equals l.Id
                               select new {descripcionventa = j.Total,
                               descripcioncliente = l.Nombres
                               };
            foreach (var item in clienteventa)
            {
                Console.WriteLine("{0}= {1}", item.descripcioncliente,item.descripcionventa);
            }

            //Cliente con las ventas realizadas menos de un año
            Console.WriteLine("\n{Cliente con la venta con menos de 1 año}");     
            var fechamenosdeunaño = from m in listafactura
                                    join a in listacliente on m.IdCliente equals a.Id
                                    orderby m.Fecha select new { dcliente = a.Nombres, m.Fecha };
            DateTime fecha = DateTime.Today;
            foreach (var item in fechamenosdeunaño)
            {
                if (item.Fecha >= fecha)
                {
                    Console.WriteLine("{0} = {1}",item.Fecha,item.dcliente);
                }
            }

            //Venta mas antigua
            Console.WriteLine("\n{Cliente con la venta mas antigua}");
            var fechamasantigua = from mi in listafactura
                                  join al in listacliente on mi.IdCliente equals al.Id
                                  where mi.Fecha <= Convert.ToDateTime("2011-11-2")
                                  orderby mi.Fecha
                                  select new { dcliente = al.Nombres, mi.Fecha };   
            foreach (var item in fechamasantigua)
            {
                {
                    Console.WriteLine("{0} = {1}",item.Fecha, item.dcliente);
                }
            }

            //Ultima venta
            Console.WriteLine("\n{Cliente con la ultima venta}");
            var ultimaventa = from mm in listafactura
                                  join am in listacliente on mm.IdCliente equals am.Id
                                  where mm.Fecha >= Convert.ToDateTime("2019-12-23")
                                  orderby mm.Fecha
                                  select new { dcliente = am.Nombres, mm.Fecha };
            foreach (var item in ultimaventa)
            {
                if (item.Fecha > fecha)
                {
                    Console.WriteLine("{0} = {1}", item.Fecha, item.dcliente);
                }
            }

            //Observacion Prob
            Console.WriteLine("\n{Cliente con la ultima venta}");
            var observacion = from o in listafactura
                              join p in listacliente on o.IdCliente equals p.Id
                              select new { dcliente = p.Nombres,o.Observacion };
            string Prob;
            foreach (var item in observacion)
            {
                if (item.Observacion == "Prob")
                {
                    Console.WriteLine("{0} = {1}", item.Observacion, item.dcliente);
                }
                    //Console.WriteLine("{0} = {1}",item.Observacion,item.dcliente);
            }
            Console.ReadKey();
        }
    }
    class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
    }
    class Factura
    {
        public int Id { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public int IdCliente { get; set; }
    }
}

