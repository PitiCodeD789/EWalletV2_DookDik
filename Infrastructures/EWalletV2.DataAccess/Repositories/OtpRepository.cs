﻿
using EWalletV2.DataAccess.Contexts;
using EWalletV2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWalletV2.DataAccess.Repositories
{
    public class OtpRepository
    {
        private readonly DataContext _context;
        public OtpRepository(DataContext context)
        {
            _context = context;
        }        
        public bool SaveOtp(string email, string refOtp, string otpNumber)
        {
            try
            {
                OtpEntity entity = new OtpEntity()
                {
                    Email = email,
                    Reference = refOtp,
                    Otp = otpNumber
                };
                _context.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {                
                return false;
            }
        }
        public OtpEntity GetOtpEntity(string email)
        {
            try
            {
                return _context.Otps.FirstOrDefault(x => x.Email == email);
            }
            catch
            {
                return null;
            }
        }
        public void Delete(OtpEntity entity)
        {
            _context.Otps.Remove(entity);
            _context.SaveChanges();
        }
    }
}
