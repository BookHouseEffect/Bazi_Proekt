using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Reflection;

namespace Bazi_Repository.Implementation
{
    class PersonManager : BaseManager, IPersonManager
    {

        public PersonManager(): base() { }
        public PersonManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Lugje GetById(int id)
        {
            return Context.Lugje.Where(x => x.CovekId == id).SingleOrDefault();
        }

        private Lugje IsExisting(Lugje person)
        {
            return Context.Lugje.Where(
                x => x.BrojNaLicnaKarta == person.BrojNaLicnaKarta
                && x.DataNaRagjanje == person.DataNaRagjanje
                && x.Ime == person.Ime
                && x.Pol == person.Pol
                && x.Prezime == person.Prezime)
                .SingleOrDefault();
        }

        public RepoBaseResponse<Lugje> AddNewPerson(RepoAddNewPersonRequest request)
        {
            RepoBaseResponse<Lugje> response = new RepoBaseResponse<Lugje>();
            try
            {
                Lugje checkedPerson = IsExisting(request.Person);
                if (checkedPerson != null)
                    response.ReturnedResult = checkedPerson;
                else
                {
                    Context.Lugje.InsertOnSubmit(request.Person);
                    Context.SubmitChanges();
                    response.ReturnedResult = request.Person;
                }
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Lugje> GetPersonById(RepoGetPersonByIdRequest request)
        {
            RepoBaseResponse<Lugje> response = new RepoBaseResponse<Lugje>();
            try
            {
                response.ReturnedResult = GetById(request.PersonId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Lugje> GetPersonByIdCardNumber(RepoGetPersonByIdCardNumberRequest request)
        {
            RepoBaseResponse<Lugje> response = new RepoBaseResponse<Lugje>();
            try
            {
                response.ReturnedResult = Context.Lugje.Where(x => x.BrojNaLicnaKarta == request.IdCardNumber).SingleOrDefault();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Lugje>> GetPersonByNameOrSurname(RepoGetPersonByNameOrSurnameRequest request)
        {
            RepoBaseResponse<ICollection<Lugje>> response = new RepoBaseResponse<ICollection<Lugje>>();
            try
            {
                response.ReturnedResult = Context.Lugje.Where(
                    x => x.Ime.Contains(request.Name) && x.Ime.Contains(request.Surname))
                    .ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Lugje> UpdatePersonInfo(RepoUpdatePersonInfoRequest request)
        {
            RepoBaseResponse<Lugje> response = new RepoBaseResponse<Lugje>();
            try
            {
                Lugje person = GetById(request.PersonId);
                if (person == null)
                    return AddNewPerson(
                        new RepoAddNewPersonRequest { Person = request.NewPerson });
                else
                {
                    Lugje newPersonExistance = IsExisting(request.NewPerson);
                    if (newPersonExistance != null)
                        response.ReturnedResult = newPersonExistance;
                    else
                    {
                        int usageCount = person.Patnicis_CovekId.Count() + person.Vrabotenis_CovekId.Count();
                        if (usageCount > 1)
                            return AddNewPerson(
                                new RepoAddNewPersonRequest { Person = request.NewPerson });
                        else
                        {
                            foreach (PropertyInfo property in typeof(Lugje).GetProperties())
                            {
                                property.SetValue(person, property.GetValue(request.NewPerson, null), null);
                            }
                            Context.SubmitChanges();
                            response.ReturnedResult = person;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
