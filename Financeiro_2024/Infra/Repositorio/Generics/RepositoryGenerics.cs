using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.Generics
{
    public class RepositoryGenerics<T> : InterfaceGeneric<T> where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(Objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(Objecto);
                await data.SaveChangesAsync();
            }
        }
    }
}
