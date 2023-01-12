using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Shoepify.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Infrastructure.Extensions
{
    public static class RequestQueryExtensions
    {
        public static List<Shoe> GetFilteredShoes(this IQueryCollection query, List<Shoe> collection)
        {
            StringValues nameParam = query["name"];
            StringValues genderParam = query["gender"];
            StringValues categoryParam = query["category"];

            if (nameParam.Count != 0 && nameParam[0] != null)
            {
                collection = collection.Where(x => $"{x.Brand} {x.Model}".ToLower().Contains(nameParam[0]?.ToLower())).ToList();
            }
            if (genderParam.Count != 0 && genderParam[0] != null)
            {
                collection = collection.Where(x => x.Gender.ToString().ToLower() == genderParam[0]?.ToLower()).ToList();
            }
            if (categoryParam.Count != 0 && categoryParam[0] != null)
            {
                collection = collection.Where(x => x.Category?.Name?.ToLower() == categoryParam[0]?.ToLower()).ToList();
            }

            return collection;
        }
    }
}
