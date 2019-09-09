﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWalletV2.Api.ViewModels.Pin;
using EWalletV2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EWalletV2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public PinController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        //LoginByPin
        //CheckPin
        //UpdatePin
        //CheckForgotPin
        [HttpPost("CheckForgotPin")]
        public IActionResult CheckForgotPin([FromBody] CheckForgotPinCommand forgotPinCommand)
        {
            bool isUser = _userService.CheckUserByEmailAndBirthday(forgotPinCommand.Email, forgotPinCommand.Birthday);
            if (!isUser)
            {
                return NoContent();
            }
            string refNumber = _authService.SaveOtp(forgotPinCommand.Email);
            if (string.IsNullOrEmpty(refNumber))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error" });
            }


            return Ok(refNumber);


        }

    }
}