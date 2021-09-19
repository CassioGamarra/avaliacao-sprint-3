using Newtonsoft.Json;
using FichaRPG.Interface;
using FichaRPG.Model;
using FichaRPG.RootClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FichaRPG
{
    class Program : IDataService
    {  
        static async Task Main(string[] args)
        {
            Program p = new Program();

            Task<AtributosRoot> atributosRootEnumerable = null;
            Task<ClassesRoot> classesRootEnumerable = null;
            Task<IdsRoot> idsRootEnumerable = null;

            Parallel.Invoke
            (
                () =>
                {
                    atributosRootEnumerable = p.ObterAtributosDeClasseAsync();
                },
                () =>
                {
                    classesRootEnumerable = p.ObterClassesAsync();
                },
                () =>
                {
                    idsRootEnumerable = p.ObterIdsFiltradosAsync();
                }
            );

            atributosRootEnumerable.Wait();
            classesRootEnumerable.Wait();
            idsRootEnumerable.Wait();

            List<Classes> listaClasses = new List<Classes>();
            Parallel.ForEach(classesRootEnumerable.Result.Classes, c =>
            {
                Parallel.ForEach(idsRootEnumerable.Result.Ids, i =>
                {
                    if (c.Id == i)
                    {
                        lock(listaClasses)
                        {
                            var id = c;
                            listaClasses.Add(id);
                        }
                    }
                });
            });

            Parallel.ForEach(listaClasses, c =>
            {
                Parallel.ForEach(atributosRootEnumerable.Result.Atributos, a =>
                {
                    if (c.Id == a.ClasseId)
                    {
                        lock (listaClasses)
                        {
                            c.Atributos = a;
                        }
                    }
                });
            });

            foreach (var item in listaClasses)
            {
                Console.WriteLine(@$"       ----    ----        ---         ");
                Console.WriteLine(@$"Id: {item.Id}                          ");
                Console.WriteLine(@$"Nome: {item.NomeClasse}                ");
                Console.WriteLine(@$"      Atributos                        ");
                Console.WriteLine(@$"FOR: {item.Atributos.Forca}            ");
                Console.WriteLine(@$"DES: {item.Atributos.Destreza}         ");
                Console.WriteLine(@$"INT: {item.Atributos.Inteligencia}     ");
                Console.WriteLine(@"                                        ");
            }
        }

        public async Task<AtributosRoot> ObterAtributosDeClasseAsync()
        {
            Task<AtributosRoot> task;
            string jsonString = await File.ReadAllTextAsync(@"JSONFiles/atributos.json");
            task = Task.Run(() => { return JsonConvert.DeserializeObject<AtributosRoot>(jsonString); });
            return await task; 
        }

        public async Task<ClassesRoot> ObterClassesAsync()
        {
            Task<ClassesRoot> task;
            string jsonString = await File.ReadAllTextAsync(@"JSONFiles/classes.json");
            task = Task.Run(() => { return JsonConvert.DeserializeObject<ClassesRoot>(jsonString); });
            return await task;
        }

        public async Task<IdsRoot> ObterIdsFiltradosAsync()
        {
            Task<IdsRoot> task;
            string jsonString = await File.ReadAllTextAsync(@"JSONFiles/ids_filtrados.json");
            task = Task.Run(() => { return JsonConvert.DeserializeObject<IdsRoot>(jsonString); });
            return await task;
        }
    }
}
