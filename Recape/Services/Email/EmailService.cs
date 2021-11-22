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
            var htmlContent = $"<strong>{email.Corpo}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }

        public string FormatarCorpoEmail(int id, string cliente, string dataHorario, string total, string servico)
        {
            var corpo = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'><html data-editor-version='2' class='sg-campaigns' xmlns='http://www.w3.org/1999/xhtml'>    <head>      <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>      <meta name='viewport' content='width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1'>      <!--[if !mso]><!-->      <meta http-equiv='X-UA-Compatible' content='IE=Edge'>      <!--<![endif]-->      <!--[if (gte mso 9)|(IE)]>      <xml>        <o:OfficeDocumentSettings>          <o:AllowPNG/>          <o:PixelsPerInch>96</o:PixelsPerInch>        </o:OfficeDocumentSettings>      </xml>      <![endif]-->      <!--[if (gte mso 9)|(IE)]>  <style type='text/css'>    body {width: 600px;margin: 0 auto;}    table {border - collapse: collapse;}    table, td {mso - table - lspace: 0pt;mso-table-rspace: 0pt;}    img {-ms - interpolation - mode: bicubic;}  </style><![endif]-->      <style type='text/css'>    body, p, div {      font - family: inherit;      font-size: 14px;    }    body {      color: #000000;    }    body a {      color: #1188E6;      text-decoration: none;    }    p { margin: 0; padding: 0; }    table.wrapper {      width:100% !important;      table-layout: fixed;      -webkit-font-smoothing: antialiased;      -webkit-text-size-adjust: 100%;      -moz-text-size-adjust: 100%;      -ms-text-size-adjust: 100%;    }    img.max-width {      max - width: 100% !important;    }    .column.of-2 {      width: 50%;    }    .column.of-3 {      width: 33.333%;    }    .column.of-4 {      width: 25%;    }    ul ul ul ul  {      list - style - type: disc !important;    }    ol ol {      list - style - type: lower-roman !important;    }    ol ol ol {      list - style - type: lower-latin !important;    }    ol ol ol ol {      list - style - type: decimal !important;    }    @media screen and (max-width:480px) {      .preheader.rightColumnContent,      .footer.rightColumnContent {        text-align: left !important;      }      .preheader .rightColumnContent div,      .preheader .rightColumnContent span,      .footer .rightColumnContent div,      .footer .rightColumnContent span {        text-align: left !important;      }      .preheader .rightColumnContent,      .preheader .leftColumnContent {        font-size: 80% !important;        padding: 5px 0;      }      table.wrapper-mobile {        width: 100% !important;        table-layout: fixed;      }      img.max-width {        height: auto !important;        max-width: 100% !important;      }      a.bulletproof-button {        display: block !important;        width: auto !important;        font-size: 80%;        padding-left: 0 !important;        padding-right: 0 !important;      }      .columns {        width: 100% !important;      }      .column {        display: block !important;        width: 100% !important;        padding-left: 0 !important;        padding-right: 0 !important;        margin-left: 0 !important;        margin-right: 0 !important;      }      .social-icon-column {        display: inline-block !important;      }    }  </style>      <!--user entered Head Start--><link href='https://fonts.googleapis.com/css?family=Viga&display=swap' rel='stylesheet'><style>    body {font - family: 'Viga', sans-serif;}</style><!--End Head user entered-->    </head>    <body>      <center class='wrapper' data-link-color='#1188E6' data-body-style='font-size:14px; font-family:inherit; color:#000000; background-color:#f0f0f0;'>        <div class='webkit'>          <table cellpadding='0' cellspacing='0' border='0' width='100%' class='wrapper' bgcolor='#f0f0f0'>            <tr>              <td valign='top' bgcolor='#f0f0f0' width='100%'>                <table width='100%' role='content-container' class='outer' align='center' cellpadding='0' cellspacing='0' border='0'>                  <tr>                    <td width='100%'>                      <table width='100%' cellpadding='0' cellspacing='0' border='0'>                        <tr>                          <td>                            <!--[if mso]>    <center>    <table><tr><td width='600'>  <![endif]-->                                    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='width:100%; max-width:600px;' align='center'>                                      <tr>                                        <td role='modules-container' style='padding:0px 0px 0px 0px; color:#000000; text-align:left;' bgcolor='#ffffff' width='100%' align='left'><table class='module preheader preheader-hide' role='module' data-type='preheader' border='0' cellpadding='0' cellspacing='0' width='100%' style='display: none !important; mso-hide: all; visibility: hidden; opacity: 0; color: transparent; height: 0; width: 0;'>    <tr>      <td role='module-content'>        <p></p>      </td>    </tr>  </table><table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' role='module' data-type='columns' style='padding:30px 20px 40px 30px;' bgcolor='#77dedb' data-distribution='1'>    <tbody>      <tr role='module-content'>        <td height='100%' valign='top'><table width='550' style='width:550px; border-spacing:0; border-collapse:collapse; margin:0px 0px 0px 0px;' cellpadding='0' cellspacing='0' align='left' border='0' bgcolor='' class='column column-0'>      <tbody>        <tr>          <td style='padding:0px;margin:0px;border-spacing:0;'><table class='wrapper' role='module' data-type='image' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='b422590c-5d79-4675-8370-a10c2c76af02'>    <tbody>      <tr>        <td style='font-size:6px; line-height:10px; padding:0px 0px 0px 0px;' valign='top' align='left'>          <img class='max-width' border='0' style='display:block; color:#000000; text-decoration:none; font-family:Helvetica, arial, sans-serif; font-size:16px;' width='280' alt='' data-proportionally-constrained='true' data-responsive='false' src='https://gsampaiolima.blob.core.windows.net/$web/recape/recape_logo.png?sp=r&st=2021-11-22T16:44:28Z&se=2023-11-23T00:44:28Z&sv=2020-08-04&sr=b&sig=TjfKNnC8F6weig58hL85nbi3fVrrVHYgLKbuoUEa7zU%3D' height='35'>        </td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='1995753e-0c64-4075-b4ad-321980b82dfe' data-mc-module-version='2019-10-22'>    <tbody>      <tr>        <td style='padding:100px 0px 18px 0px; line-height:36px; text-align:inherit;' height='100%' valign='top' bgcolor='' role='module-content'><div><div style='font-family: inherit; text-align: inherit'><span style='color: #ffffff; font-size: 40px; font-family: inherit'>Recebemos sua ordem de serviço #" + id + "</span></div><div></div></div></td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='2ffbd984-f644-4c25-9a1e-ef76ac62a549' data-mc-module-version='2019-10-22'>    <tbody>      <tr>        <td style='padding:18px 20px 20px 0px; line-height:24px; text-align:inherit;' height='100%' valign='top' bgcolor='' role='module-content'><div><div style='font-family: inherit; text-align: inherit'><span style='font-size: 24px'>Obrigado por confiar no nosso trabalho! 😀</span></div><div></div></div></td>      </tr>    </tbody>  </table></td>        </tr>      </tbody>    </table></td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='8b5181ed-0827-471c-972b-74c77e326e3d' data-mc-module-version='2019-10-22'>    <tbody>      <tr>        <td style='padding:30px 20px 18px 30px; line-height:22px; text-align:inherit;' height='100%' valign='top' bgcolor='' role='module-content'><div><div style='font-family: inherit; text-align: inherit'><span style='color: #0055ff; font-size: 24px'>Resumo</span></div><div></div></div></td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='divider' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='f7373f10-9ba4-4ca7-9a2e-1a2ba700deb9'>    <tbody>      <tr>        <td style='padding:0px 30px 0px 30px;' role='module-content' height='100%' valign='top' bgcolor=''>          <table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' height='3px' style='line-height:3px; font-size:3px;'>            <tbody>              <tr>                <td style='padding:0px 0px 3px 0px;' bgcolor='#e7e7e7'></td>              </tr>            </tbody>          </table>        </td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='264ee24b-c2b0-457c-a9c1-d465879f9935' data-mc-module-version='2019-10-22'>    <tbody>      <tr>        <td style='padding:18px 20px 18px 30px; line-height:22px; text-align:inherit;' height='100%' valign='top' bgcolor='' role='module-content'><div><div style='font-family: inherit; text-align: inherit'>ID Único: " + id + "</div><div style='font-family: inherit; text-align: inherit'><span style='color: #0055ff'><strong>Email do Cliente: " + cliente + "</strong></span></div><div style='font-family: inherit; text-align: inherit'><br></div><div style='font-family: inherit; text-align: inherit'>Serviço: " + servico + "</div><div style='font-family: inherit; text-align: inherit'>Agendado para: " + dataHorario + "</div>      </tr>    </tbody>  </table><table class='module' role='module' data-type='divider' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='f7373f10-9ba4-4ca7-9a2e-1a2ba700deb9.1'>    <tbody>      <tr>        <td style='padding:20px 30px 0px 30px;' role='module-content' height='100%' valign='top' bgcolor='#FFFFFF'>          <table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' height='3px' style='line-height:3px; font-size:3px;'>            <tbody>              <tr>                <td style='padding:0px 0px 3px 0px;' bgcolor='#E7E7E7'></td>              </tr>            </tbody>          </table>        </td>      </tr>    </tbody>  </table><table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;' data-muid='264ee24b-c2b0-457c-a9c1-d465879f9935.1' data-mc-module-version='2019-10-22'>    <tbody>      <tr>        <td style='padding:18px 20px 30px 30px; line-height:22px; text-align:inherit; background-color:#FFFFFF;' height='100%' valign='top' bgcolor='#FFFFFF' role='module-content'><div><br>Total</div><div style='font-family: inherit; text-align: inherit'><br></div><div style='font-family: inherit; text-align: inherit'><span style='color: #0055ff; font-size: 32px; font-family: inherit'>R$ " + total + "</span></div><div></div></div></td>      </tr>    </tbody>  </table><div data-role='module-unsubscribe' class='module' role='module' data-type='unsubscribe' style='background-color:#0055ff; color:#ffffff; font-size:12px; line-height:20px; padding:16px 16px 16px 16px; text-align:Center;' data-muid='4e838cf3-9892-4a6d-94d6-170e474d21e5'><p style='font-size:12px; line-height:20px;'><a class='Unsubscribe--unsubscribeLink' href='#' style='color:#77dedb;'>2021 - Recape Comércio e Serviços Automotivos</a></p></div><table border='0' cellpadding='0' cellspacing='0' class='module' data-role='module-button' data-type='button' role='module' style='table-layout:fixed;' width='100%' data-muid='e5cea269-a730-4c6b-8691-73d2709adc62'>      <tbody>        <tr>          <td align='center' bgcolor='0055FF' class='outer-td' style='padding:0px 0px 20px 0px; background-color:0055FF;'>            <table border='0' cellpadding='0' cellspacing='0' class='wrapper-mobile' style='text-align:center;'>              <tbody>                <tr>                <td align='center' bgcolor='#f5f8fd' class='inner-td' style='border-radius:6px; font-size:16px; text-align:center; background-color:inherit;'><a href='https://www.sendgrid.com/?utm_source=powered-by&utm_medium=email' style='background-color:#f5f8fd; border:1px solid #f5f8fd; border-color:#f5f8fd; border-radius:25px; border-width:1px; color:#a8b9d5; display:inline-block; font-size:10px; font-weight:normal; letter-spacing:0px; line-height:normal; padding:5px 18px 5px 18px; text-align:center; text-decoration:none; border-style:solid; font-family:helvetica,sans-serif;' target='_blank'>POWERED BY TWILIO SENDGRID</a></td>                </tr>              </tbody>            </table>          </td>        </tr>      </tbody>    </table></td>                                      </tr>                                    </table>                                    <!--[if mso]>                                  </td>                                </tr>                              </table>                            </center>                            <![endif]-->                          </td>                        </tr>                      </table>                    </td>                  </tr>                </table>              </td>            </tr>          </table>        </div>      </center>    </body>  </html>";

            return corpo;
        }
    }
}
