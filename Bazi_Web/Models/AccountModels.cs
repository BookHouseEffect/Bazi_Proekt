using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Db201617zVaProektRnabContext;
using Bazi_Business.Implementation;
using Bazi_Business.Responses;
using static Bazi_Web.Controllers.AccountController;
using System.Web.Mvc;

namespace Bazi_Web.Models
{
    public class InformationBaseModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("ModelType");
            var type = Type.GetType(
                (string)typeValue.ConvertTo(typeof(string)),
                true
            );
            if (!typeof(InformationViewModel).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type");
            }
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }

    public class ChangePassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your current password")]
        [Display(Name = "Old Password:")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!-\\/:-@\\[-`{-~])[!-~]{8,20}$",
            ErrorMessage = "The password must be between 8 and 20 character including at least one uppercase character, at least one lowercase character, at least one number and one special character.")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your new password")]
        [Display(Name = "New Password:")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!-\\/:-@\\[-`{-~])[!-~]{8,20}$",
            ErrorMessage = "The password must be between 8 and 20 character including at least one uppercase character, at least one lowercase character, at least one number and one special character.")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please reenter your new password.")]
        [Display(Name = "Repeat New Password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Passwords must match.")]
        public string RepeatePassword { get; set; }
    }

    public class AccountBaseModel
    {
        public int AccountId { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter your username.")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!-\\/:-@\\[-`{-~])[!-~]{8,20}$",
            ErrorMessage = "The password must be between 8 and 20 character including at least one uppercase character, at least one lowercase character, at least one number and one special character.")]
        public string Password { get; set; }
    }

    public class LogInViewModel : AccountBaseModel
    {
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : AccountBaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email address.")]
        [Display(Name = "Email Adderss:")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$",
            ErrorMessage = "Enter a valid email address.")]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please reenter your password.")]
        [Display(Name = "Repeat Password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match.")]
        public string RepeatePassword { get; set; }

        public AccountTypes SelectedAccountType { get; set; }
        public InformationViewModel Infomation { get; set; }

        public RegisterViewModel() { }

        public RegisterViewModel(AccountTypes accountType)
        {
            this.SelectedAccountType = accountType;
            switch (accountType)
            {
                case AccountTypes.EMPLOYEE:
                    this.Infomation = new EmployeeViewModel();
                    break;
                case AccountTypes.COMPANY:
                    this.Infomation = new CompanyViewModel();
                    break;
                case AccountTypes.PASSENGER:
                    this.Infomation = new PassengersViewModel();
                    break;
                default:
                    throw new Exception("No such account type.");
            }
        }

        public Akaunti ParseToAkaunti()
        {
            return new Akaunti { AkauntId = this.AccountId, EmailAdresa = this.EmailAddress, KorisnichkoIme = this.Username };
        }
    }

    public class EditViewModel{

        public AccountTypes SelectedAccountType { get; set; }
        public ICollection<InformationViewModel> Infomation { get; set; }
        public ChangePassword Passwords { get; set; } = new ChangePassword();

        public EditViewModel() {}

        public EditViewModel(ICollection<Patnici> passengers) {
            this.SelectedAccountType = AccountTypes.PASSENGER;
            this.Infomation = new List<InformationViewModel>();
            foreach (Patnici p in passengers)
                this.Infomation.Add(new PassengersViewModel(p));
        }

        public EditViewModel(Aviokompanii company)
        {
            this.SelectedAccountType = AccountTypes.COMPANY;
            this.Infomation = new List<InformationViewModel>();
            this.Infomation.Add(new CompanyViewModel(company)); 
        }
    }

    public abstract class InformationViewModel
    {

    }

    public class PersonViewModel : InformationViewModel
    {
        public int PersonId { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your surname.")]
        [Display(Name = "Surname:")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, choose your gender.")]
        [Display(Name = "Gender:")]
        public String Gender { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; } =
            new List<SelectListItem>() {
                new SelectListItem() {Value = "0", Text = "Male" },
                new SelectListItem() {Value = "1", Text = "Female" }
            };

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter your date of birth.")]
        [Display(Name = "Date of birth:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your ID Number.")]
        [Display(Name = "ID Number:")]
        public string IDCardNumber { get; set; }

        public Lugje ParseToLugje()
        {
            return new Lugje {CovekId = PersonId, BrojNaLicnaKarta = this.IDCardNumber, DataNaRagjanje = this.DateOfBirth, Ime = this.Name, Pol = this.Gender == "0" ? false : true, Prezime = this.Surname };
        }

        public PersonViewModel() { }

        public PersonViewModel(Lugje l)
        {
            this.PersonId = l.CovekId;
            this.Name = l.Ime;
            this.Surname = l.Prezime;
            this.Gender = l.Pol ? "1" : "0";
            this.DateOfBirth = l.DataNaRagjanje;
            this.IDCardNumber = l.BrojNaLicnaKarta;
        }
    }

    public class PassengersViewModel : PersonViewModel
    {
        public int PassengerId { get; set; }

        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your Passport number.")]
        [Display(Name = "Passport number:")]
        public string PassportNumber { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the date of passport issue.")]
        [Display(Name = "Date of passport issue:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime DateOfIssue { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the authority.")]
        [Display(Name = "Authority:")]
        public string Authority { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the date of passport expire.")]
        [Display(Name = "Date of passport expire:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfExpire { get; set; }

        public AddressViewModel Address { get; set; }

        public Patnici ParseToPatnici()
        {
            return new Patnici {PatnikId = PassengerId, BrojNaPasosh = this.PassportNumber, DatumNaIzdavanje = this.DateOfIssue, Izdadenod = this.Authority, DatumNaIstekuvanje = this.DateOfExpire, Status = (this.DateOfExpire > DateTime.Now) };
        }

        public PassengersViewModel()
        {
            Address = new AddressViewModel();
        }

        public PassengersViewModel(Patnici p) : base(p.Lugje_CovekId)
        {
            this.PassengerId = p.PatnikId;
            this.PassportNumber = p.BrojNaPasosh;
            this.DateOfIssue = p.DatumNaIzdavanje;
            this.Authority = p.Izdadenod;
            this.DateOfExpire = p.DatumNaIstekuvanje;
            this.Address = new AddressViewModel(p.Adresi_AdresaId);
        }

    }

    public class EmployeeViewModel : PersonViewModel
    {        
        public Vraboteni ParseToVraboteni()
        {
            return new Vraboteni();
        }
    }

    public class CompanyViewModel : InformationViewModel
    {
        public int CompanyId { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter the company name.")]
        [Display(Name = "Company name:")]
        public string CompanyName { get; set; }

        public AddressViewModel Address { get; set; }

        public CompanyViewModel()
        {
            Address = new AddressViewModel();
        }

        public CompanyViewModel(Aviokompanii company)
        {
            this.CompanyId = company.KompanijaId;
            this.CompanyName = company.ImeNaKompanija;
            this.Address = new AddressViewModel(company.Adresi_AdresaId);
        }

        public Aviokompanii ParseToAviokompanii()
        {
            return new Aviokompanii {KompanijaId = this.CompanyId, ImeNaKompanija = this.CompanyName };
        }
    }

    public class AddressViewModel {

        public int AddressId { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the steet name.")]
        [Display(Name = "Steet name:")]
        public string StreetName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the steet number.")]
        [Display(Name = "Steet number:")]
        public string StreetNumber { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the city name.")]
        [Display(Name = "City name:")]
        public string CityName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the zip code.")]
        [Display(Name = "Zip Code:")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Display(Name = "Region name:")]
        public string RegionName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the state name.")]
        [Display(Name = "State name:")]
        public string StateName { get; set; }

        public AddressViewModel() { }

        public AddressViewModel(Adresi address)
        {
            this.AddressId = address.AdresaId;
            this.CityName = address.Grad;
            this.RegionName = address.Oblast;
            this.StateName = address.Drzhava;
            this.StreetName = address.ImeNaUlica;
            this.StreetNumber = address.Broj;
            this.ZipCode = address.PoshtenskiBroj;
        }

        public Adresi ParseToAdresi()
        {
            return new Adresi {AdresaId = this.AddressId, Broj = this.StreetNumber, Drzhava = this.StateName, Grad = this.CityName, ImeNaUlica = this.StreetName, Oblast = this.RegionName, PoshtenskiBroj = this.ZipCode };
        }
    }
}