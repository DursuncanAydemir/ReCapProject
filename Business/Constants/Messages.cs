using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç eklendi!";
        public static string CarDeleted = "Araç silindi!";
        public static string CarUpdated = "Araç bilgileri güncellendi!";
        public static string CarNameInvalid = "Araç ismi geçersiz!";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string CarListed = "Araç listelendi!";
        public static string CarRented = "Araç kirada!";
        public static string AuthorizationDenied="Yetkiniz yok!";
        public static string UserRegistered="Kayıt oldu!";
        public static string UserNotFound="Kullanıcı bulunamadı!";
        public static string PasswordError="Şifre yanlış!";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut!";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
