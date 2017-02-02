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
    public class AccountBaseModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("ModelType");
            var type = Type.GetType(
                (string)typeValue.ConvertTo(typeof(string)),
                true
            );
            if (!typeof(AccountBaseModel).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type");
            }
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }

    public abstract class AccountBaseModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter your username")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email address")]
        [Display(Name = "Email Adderss:")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$",
            ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please reenter your password")]
        [Display(Name = "Repeat Password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string RepeatePassword { get; set; }

        public AccountTypes SelectedAccountType { get; set; }

    }

    public class PersonViewModel : RegisterViewModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter your name")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your surname")]
        [Display(Name = "Surname:")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, choose your gender:")]
        [Display(Name = "Gender:")]
        public String Gender { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; } =
            new List<SelectListItem>() {
                new SelectListItem() {Value = "0", Text = "Male" },
                new SelectListItem() {Value = "1", Text = "Female" }
            };

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter your date of birth:")]
        [Display(Name = "Date of birth:")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your ID Number")]
        [Display(Name = "ID Number:")]
        public string IDCardNumber { get; set; }
    }

    public class PassengersViewModel : PersonViewModel
    {
        [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Please enter your Passport number")]
        [Display(Name = "Passport number:")]
        public string PassportNumber { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the date of passport issue:")]
        [Display(Name = "Date of passport issue:")]
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the authority:")]
        [Display(Name = "Authority:")]
        public string Authority { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the date of passport expire:")]
        [Display(Name = "Date of passport expire:")]
        [DataType(DataType.Date)]
        public DateTime DateOfExpire { get; set; }

        public AddressViewModel Address { get; set; }

        public PassengersViewModel()
        {
            Address = new AddressViewModel();
        }

    }

    public class EmployeeViewModel : PersonViewModel
    {
        
    }

    public class CompanyViewModel : RegisterViewModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please enter the company name")]
        [Display(Name = "Company name:")]
        public string CompanyName { get; set; }

        public AddressViewModel Address { get; set; }

        public CompanyViewModel()
        {
            Address = new AddressViewModel();
        }
    }

    public class AddressViewModel {

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the steet name:")]
        [Display(Name = "Steet name:")]
        public string StreetName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the steet number:")]
        [Display(Name = "Steet number:")]
        public string StreetNumber { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the city name:")]
        [Display(Name = "City name:")]
        public string CityName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the zip code:")]
        [Display(Name = "Zip Code:")]
        public string ZipCode { get; set; }

        [Display(Name = "Region name:")]
        public string RegionName { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please, enter the state name:")]
        [Display(Name = "State name:")]
        public string StateName { get; set; }
    }
}