using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHero.Mappers
{
    public static class HeroMappers
    {
        public static IEnumerable<DAO.Models.Hero> toDAO(this IEnumerable<int> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return new DAO.Models.Hero { Id = dto };
            }
        }
    }
}
