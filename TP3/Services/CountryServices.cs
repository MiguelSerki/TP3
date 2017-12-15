using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO;
using Data;

namespace Services
{
    public class CountryServices
    {
        private Repository<Country> CountryRepo = new Repository<Country>();

        public void Create(CountryDTO entity)
        {
            var country = new Country
            {
                CountryName = entity.CountryName
            };
            this.CountryRepo.Persist(country);
            this.CountryRepo.SaveChanges();
        }

        public CountryDTO CreateFromString(string name)
        {
            return new CountryDTO()
            {
                CountryName = name
            };
        }

        public void Delete(CountryDTO entity)
        {
            try
            {
                var country = this.CountryRepo.Set().Where(c => c.CountryName == entity.CountryName).FirstOrDefault();
                this.CountryRepo.Remove(country);
                this.CountryRepo.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("No existe ese pais");
            }

        }

        public List<CountryDTO> ListAll()
        {
            var countries = this.CountryRepo.Set();
            List<CountryDTO> list = new List<CountryDTO>();
            try
            {
                foreach (var item in countries)
                {
                    list.Add(this.CountryMapper(item));
                }
                return list;
            }
            catch (Exception)
            {
                Console.WriteLine("No hay paises");
                return null;
            }
            
        }

        public void Read(CountryDTO entity)
        {
           
        }

        public void Update(string entity, string name)
        {
            var country = this.CountryRepo.Set().Where(c => c.CountryName == name).FirstOrDefault();
            country.CountryName = entity;
            this.CountryRepo.Update(country);
            this.CountryRepo.SaveChanges();
        }

        public CountryDTO CountryMapper(Country c)
        {
            return new CountryDTO
            {
                CountryName = c.CountryName
            };
        }
    }
}
