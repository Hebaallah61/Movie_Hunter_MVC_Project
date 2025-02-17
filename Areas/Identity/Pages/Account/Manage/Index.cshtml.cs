﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly ILookValueRepo _lookValueRepo;
        private readonly IGenericRepo<LookUpTable> _lookuptable;
        private readonly UserManager<SystemUser> _userManager;
        private readonly SignInManager<SystemUser> _signInManager;

        public IndexModel(
            UserManager<SystemUser> userManager,
            SignInManager<SystemUser> signInManager, ILookValueRepo _lookValueRepo, IGenericRepo<LookUpTable> _lookuptable)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._lookValueRepo = _lookValueRepo;
            this._lookuptable = _lookuptable;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Plesae enter First name")]
            [RegularExpression(@"^[A-Za-z]{1,15}$", ErrorMessage = "First Name should contain only alphabetical characters with maximum length of 15")]
            public string First_Name { get; set; }
            [Required(ErrorMessage = "Plesae enter last name")]
            [RegularExpression(@"^[A-Za-z]{1,15}$", ErrorMessage = "First Name should contain only alphabetical characters with maximum length of 15")]
            public string Last_Name { get; set; }
            [Display(Name ="Payment Method")]
            public int? PaymentMethod_Id { get; set; }

            [Display(Name ="Favorite Category")]
            public int? Category_Id { get; set; }

            [Display(Name ="Current Plan")]
            public int? Plan_Id { get; set; }
            [Range(12, 80, ErrorMessage = "Age should be between 12-80 years")]
            public int Age { get; set; }
        }

        private async Task LoadAsync(SystemUser user)
        {

            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);




            Username = userName;
            ViewData["Categories"] = _lookValueRepo.GetByName("Category");
            ViewData["Plans"] = _lookValueRepo.GetByName("Plans");
            ViewData["Payment"] = _lookValueRepo.GetByName("Payment");
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Age = user.Age,
                First_Name=user.First_Name,
                Last_Name=user.Last_Name,
                Plan_Id=user.Plan_Id,
                Category_Id=user.Category_Id,
                PaymentMethod_Id=user.PaymentMethod_Id,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user.Age=Input.Age;
            user.First_Name=Input.First_Name;
            user.Last_Name=Input.Last_Name;
            user.Category_Id=Input.Category_Id;
            user.PaymentMethod_Id=Input.PaymentMethod_Id;
            user.Plan_Id=Input.Plan_Id;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
