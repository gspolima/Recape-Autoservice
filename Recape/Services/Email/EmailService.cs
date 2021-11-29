﻿using Microsoft.Extensions.Configuration;
using Recape.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Recape.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> EnviarEmailAsync(EmailAutomatico email)
        {
            // API Key should be defined in appsettings.json
            // OR
            // set in Application settings on Azure App Services
            var apiKey = configuration.GetValue<string>("SendGrid:SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("sampaioglima@gmail.com", "Recape Autopeças");
            var subject = email.Assunto;
            var to = new EmailAddress(email.Destinatario);
            var plainTextContent = email.Corpo;
            var htmlContent = email.Corpo;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }

        public string FormatarCorpoEmail(int id, string nomeCliente, string emailCliente, string data, string horario, string total, string servico)
        {
            var corpo = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'><head><!--[if gte mso 9]><xml>  <o:OfficeDocumentSettings>    <o:AllowPNG/>    <o:PixelsPerInch>96</o:PixelsPerInch>  </o:OfficeDocumentSettings></xml><![endif]-->  <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>  <meta name='viewport' content='width=device-width, initial-scale=1.0'>  <meta name='x-apple-disable-message-reformatting'>  <!--[if !mso]><!--><meta http-equiv='X-UA-Compatible' content='IE=edge'><!--<![endif]-->  <title></title>      <style type='text/css'>      table, td { color: #000000; } @media (max-width: 480px) { #u_content_text_1 .v-container-padding-padding { padding: 25px 20px 20px !important; } }@media only screen and (min-width: 620px) {  .u - row {    width: 600px !important;  }  .u-row .u-col {    vertical-align: top;  }  .u-row .u-col-33p33 {    width: 199.98px !important;  }  .u-row .u-col-50 {    width: 300px !important;  }  .u-row .u-col-66p67 {    width: 400.02px !important;  }  .u-row .u-col-100 {    width: 600px !important;  }}@media (max-width: 620px) {  .u - row - container {    max-width: 100% !important;    padding-left: 0px !important;    padding-right: 0px !important;  }  .u-row .u-col {    min-width: 320px !important;    max-width: 100% !important;    display: block !important;  }  .u-row {    width: calc(100% - 40px) !important;  }  .u-col {    width: 100% !important;  }  .u-col > div {    margin: 0 auto;  }}body {  margin: 0;  padding: 0;}table,tr,td {  vertical - align: top;  border-collapse: collapse;}p {  margin: 0;}.ie-container table,.mso-container table {  table - layout: fixed;}* {  line - height: inherit;}a[x-apple-data-detectors='true'] {  color: inherit !important;  text-decoration: none !important;}</style>    <link rel='preconnect' href='https://fonts.googleapis.com'> <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin><link href='https://fonts.googleapis.com/css?family=Lato:400,700&display=swap' rel='stylesheet' type='text/css'></head><body class='clean-body u_body' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #707070;color: #000000'>  <!--[if IE]><div class='ie-container'><![endif]-->  <!--[if mso]><div class='mso-container'><![endif]-->  <table style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #707070;width:100%' cellpadding='0' cellspacing='0'>  <tbody>  <tr style='vertical-align: top'>    <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'>    <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td align='center' style='background-color: #707070;'><![endif]-->    <div class='u-row-container' style='padding: 29px 10px 0px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #34495e;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 29px 10px 0px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #34495e;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='200' style='background-color: #34495e;width: 200px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-33p33' style='max-width: 320px;min-width: 200px;display: table-cell;vertical-align: top;'>  <div style='background-color: #34495e;width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:20px;font-family:Lato,sans-serif;' align='left'>        <table width='100%' cellpadding='0' cellspacing='0' border='0'>  <tr>    <td style='padding-right: 0px;padding-left: 0px;' align='center'>            <img align='center' border='0' src='https://gsampaiolima.blob.core.windows.net/$web/recape/recape_logo.png?sp=r&st=2021-11-22T16:44:28Z&se=2023-11-23T00:44:28Z&sv=2020-08-04&sr=b&sig=TjfKNnC8F6weig58hL85nbi3fVrrVHYgLKbuoUEa7zU%3D' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 100%;max-width: 160px;' width='160'/>          </td>  </tr></table>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]--><!--[if (mso)|(IE)]><td align='center' width='400' style='background-color: #34495e;width: 400px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-66p67' style='max-width: 320px;min-width: 400px;display: table-cell;vertical-align: top;'>  <div style='background-color: #34495e;width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table id='u_content_text_1' style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:16px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #ffffff; line-height: 120%; text-align: right; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 120%; text-align: center;'>Se voc&ecirc; n&atilde;o consegue visualizar esse email corretamente, abra num navegador web.</p>  </div>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div><div class='u-row-container' style='padding: 0px 10px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f5f5f5;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 0px 10px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #f5f5f5;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='300' style='width: 300px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'>  <div style='width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:35px 20px 10px;font-family:Lato,sans-serif;' align='left'>          <div style='line-height: 120%; text-align: left; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 120%;'><span style='font-size: 24px; line-height: 28.8px; color: #236fa1;'><strong>Cliente</strong></span></p>  </div>      </td>    </tr>  </tbody></table><table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:10px 20px 30px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #757575; line-height: 160%; text-align: left; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 160%; text-align: justify;'>" + nomeCliente + " </ p >< p style = 'font-size: 14px; line-height: 160%; text-align: justify;'> " + emailCliente + " </ p >  </ div >      </ td >    </ tr >  </ tbody ></ table >  < !--[if (!mso) &(!IE)]>< !--></ div >< !--< ![endif]-- >  </ div ></ div >< !--[if (mso)| (IE)]></ td >< ![endif]-- >< !--[if (mso)| (IE)]>< td align = 'center' width = '300' style = 'width: 300px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign = 'top' >< ![endif]-- >< div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'>  <div style = 'width: 100% !important;' >  < !--[if (!mso) & (!IE)] >< !-->< div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style = 'font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:35px 20px 10px;font-family:Lato,sans-serif;' align='left'>          <div style = 'color: #333333; line-height: 120%; text-align: left; word-wrap: break-word;' >    < p style='font-size: 14px; line-height: 120%;'><strong><span style = 'font-size: 24px; line-height: 28.8px;' > Ordem de Servi&ccedil;o</span></strong></p>  </div>      </td>    </tr>  </tbody></table><table style = 'font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:10px 20px 30px;font-family:Lato,sans-serif;' align='left'>          <div style = 'color: #333333; line-height: 120%; text-align: left; word-wrap: break-word;' >    < p style='font-size: 14px; line-height: 120%;'><span style = 'font-size: 20px; line-height: 24px;' >< strong >#" + id + "</strong></span></p>  </div>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div><div class='u-row-container' style='padding: 0px 10px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 0px 10px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #ffffff;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='600' style='width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'>  <div style='width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:30px 20px 20px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #333333; line-height: 120%; text-align: left; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 120%;'><strong><span style='font-size: 24px; line-height: 28.8px;'>Servi&ccedil;o</span></strong></p>  </div>      </td>    </tr>  </tbody></table><table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:Lato,sans-serif;' align='left'>          <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #e3e3e3;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'>    <tbody>      <tr style='vertical-align: top'>        <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'>          <span>&#160;</span>        </td>      </tr>    </tbody>  </table>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div><div class='u-row-container' style='padding: 0px 10px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 0px 10px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #ffffff;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='400' style='width: 400px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-66p67' style='max-width: 320px;min-width: 400px;display: table-cell;vertical-align: top;'>  <div style='width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:22px 20px 20px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #333333; line-height: 140%; text-align: left; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 140%;'><span style='font-size: 20px; line-height: 28px;'>" + servico + "</span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 16px; line-height: 22.4px; color: #bb372b;'><span style='color: #000000; font-size: 16px; line-height: 22.4px;'>Agendado para</span> <strong><span style='color: #ba362b; font-size: 16px; line-height: 22.4px;'>" + data + " &agrave;s " + horario + "</span></strong></span></p>  </div>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]--><!--[if (mso)|(IE)]><td align='center' width='200' style='width: 200px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-33p33' style='max-width: 320px;min-width: 200px;display: table-cell;vertical-align: top;'>  <div style='width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:30px 20px 20px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #333333; line-height: 120%; text-align: left; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 120%;'><span style='font-size: 24px; line-height: 28.8px;'><strong><span style='line-height: 28.8px; font-size: 24px;'>R$ " + total + "</span></strong></span></p>  </div>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div><div class='u-row-container' style='padding: 0px 10px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 0px 10px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #ffffff;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='600' style='width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'>  <div style='width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:Lato,sans-serif;' align='left'>          <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #e3e3e3;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'>    <tbody>      <tr style='vertical-align: top'>        <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'>          <span>&#160;</span>        </td>      </tr>    </tbody>  </table>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div><div class='u-row-container' style='padding: 0px 10px 20px;background-color: rgba(255,255,255,0)'>  <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #17c297;'>    <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'>      <!--[if (mso)|(IE)]><table width='100%' cellpadding='0' cellspacing='0' border='0'><tr><td style='padding: 0px 10px 20px;background-color: rgba(255,255,255,0);' align='center'><table cellpadding='0' cellspacing='0' border='0' style='width:600px;'><tr style='background-color: #17c297;'><![endif]-->      <!--[if (mso)|(IE)]><td align='center' width='600' style='background-color: #34495e;width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;' valign='top'><![endif]--><div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'>  <div style='background-color: #34495e;width: 100% !important;'>  <!--[if (!mso)&(!IE)]><!--><div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'><!--<![endif]-->  <table style='font-family:Lato,sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>  <tbody>    <tr>      <td class='v-container-padding-padding' style='overflow-wrap:break-word;word-break:break-word;padding:30px 20px;font-family:Lato,sans-serif;' align='left'>          <div style='color: #ffffff; line-height: 140%; text-align: center; word-wrap: break-word;'>    <p style='font-size: 14px; line-height: 140%;'>2021 - Recape Autope&ccedil;as Servi&ccedil;os Automotivos</p>  </div>      </td>    </tr>  </tbody></table>  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->  </div></div><!--[if (mso)|(IE)]></td><![endif]-->      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->    </div>  </div></div>    <!--[if (mso)|(IE)]></td></tr></table><![endif]-->    </td>  </tr>  </tbody>  </table>  <!--[if mso]></div><![endif]-->  <!--[if IE]></div><![endif]--></body></html>";

            return corpo;
        }
    }
}
