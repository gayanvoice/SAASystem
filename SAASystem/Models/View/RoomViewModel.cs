using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class RoomViewModel
    {
        public IndexViewModel Index { get; set; }
        public ListViewModel List { get; set; }
        public InsertViewModel Insert { get; set; }
        public DeleteViewModel Delete { get; set; }
        public EditViewModel Edit { get; set; }
        public ShowViewModel Show { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
        public class ShowViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Display(Name = "Apartment Id")]
                public int ApartmentId { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    RoomContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.RoomId = contextModel.RoomId;
                    formViewModel.ApartmentId = contextModel.ApartmentId;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<RoomContextModel> RoomContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public RoomContextModel RoomContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Required]
                [Display(Name = "Apartment Id")]
                public int ApartmentId { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    RoomContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.RoomId = contextModel.RoomId;
                    formViewModel.ApartmentId = contextModel.ApartmentId;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Apartment Id")]
                public int ApartmentId { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}