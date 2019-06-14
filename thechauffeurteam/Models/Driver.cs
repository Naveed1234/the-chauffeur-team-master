using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace thechauffeurteam.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Driver Name")]
        public String DriverName { get; set; }

        [Required]
        [Display(Name = "Driver Address")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public String Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public String Nationality { get; set; }

        [Required]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public String City { get; set; }

        [Required]
        [Display(Name = "PostCode")]
        public String PostCode { get; set; }

        [Required]
        [Display(Name = "Driver Email")]
        [DataType(DataType.EmailAddress)]
        public String DriverEmail { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public String phNo { get; set; }


        [Display(Name = "Fax")]
        public String Fax { get; set; }

        [Required]
        [Display(Name = "Join Date")]
        public string JoinDate { get; set; }

        [Display(Name = "Date Left")]
        public string LeftDate { get; set; }

        [Required]
        public bool DirectCash { get; set; }

        [Required]
        public bool LikeAccount { get; set; }

        public byte[] DriverImage { get; set; }

        public String Status { get; set; }

        public String DriverId { get; set; }

    }
    public class PCOLicense
    {
        [Key]
        public int Id { get; set; }
        public int DriverID { get; set; }

        [Required]
        [Display(Name = "NI/Tax Number")]
        public string NiNumber { get; set; }

        [Required]
        [Display(Name = "Driver License Number")]
        public string DriverLicenseNo { get; set; }


        [Required]
        [Display(Name = "Driver License Issue Date")]
        public string IssueDate { get; set; }

        [Required]
        [Display(Name = "Driver License Expiry Date")]
        public string ExpiryDate { get; set; }

        [Required]
        [Display(Name = "PCO Driver License")]
        public string PcoDriverLicenseNo { get; set; }
        [Required]
        [Display(Name = "PCO Driver License Issue Date")]
        public string PcoDriverLicenseIssueDate { get; set; }

        [Required]
        [Display(Name = "PCO License Expiry Date")]
        public string PcoDriverLicenseExpiryDate { get; set; }


        [Required]
        [Display(Name = "Self Employed/UTR")]
        public string selfEmployed { get; set; }

        public byte[] LicenseImage { get; set; }

    }

    public class Vehicle
    {

        [Key]
        public int Id { get; set; }

        public int DriverID { get; set; }


        [Required]
        public String CarType { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        public String CarModel { get; set; }

        [Required]
        [Display(Name = "Make")]
        public String Make { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Registration")]
        public String Registration { get; set; }

        [Required]
        [Display(Name = "Color")]
        public String Color { get; set; }

        [Required]
        [Display(Name = "Max Passenger")]
        public int MaxPassenger { get; set; }

        [Required]
        [Display(Name = "Max Luggage")]
        public int MaxLuggage { get; set; }

        [Required]
        [Display(Name = "License NUmber")]
        public String CarLicenseNo { get; set; }

        [Required]
        [Display(Name = "License/PCO (Vehicle)Expire")]
        public string VehicleLicenseExp { get; set; }

        [Required]
        [Display(Name = "Insurance Premium")]
        public string VehicleInsurance { get; set; }

        [Required]
        [Display(Name = "Insurance Expiry")]
        public string InsuranceExpiry { get; set; }

        [Required]
        [Display(Name = "Mot Expiry")]
        public string MotExpire { get; set; }

        [Required]
        [Display(Name = "Road Tax Expiry")]
        public string RoadTaxExpiry { get; set; }

        public byte[] CarImage { get; set; }

    }

    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        public int DriverID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public String UserFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public String UserLastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String UserEmail { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        public String UserPhNo { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

    }


}

