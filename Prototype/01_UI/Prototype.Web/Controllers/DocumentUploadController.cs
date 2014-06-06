using Prototype.Common;
using Prototype.LogicLayer;
using Prototype.ModelMapper;
using Prototype.Web.Helpers;
using Prototype.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prototype.Web.Controllers
{
    public class DocumentUploadController : Controller
    {
        #region Private properties

        private IMapper mapper = new AutoMapperModelMapper();
        #endregion

        #region Gets
        
        [HttpGet]
        public ActionResult DocumentUpload()
        {
            FileUploadModel model = new FileUploadModel()
            {
                FilesToUpload = 2
            };

            //using (CustomerLL customerLL = new CustomerLL()) // Usually call a service here ..
            //{
                //... Exec some business logic if needed on the get
            //}
            return View("DocumentUpload", model);
        }
        
        [HttpGet]
        public ActionResult Confirmation()
        {
            FileUploadModel model = new FileUploadModel();

            string customerReference = "123456ABC";
            if (Session["CustomerReference"] != null)
            {
                customerReference = Session["CustomerReference"].ToString();
                model.CustomerReference = customerReference;
            }
            else
            {
                ViewData.ModelState.AddModelError("", "Confirmation Error");
                ViewBag.Message = "Document Upload Error occured. Please try again.";
            }

            return View(model);
        }

        #endregion

        #region Posts
        
        [HttpPost]
        [HttpParamAction]
        [ActionName("DocumentUpload")]
        public ActionResult Save(FileUploadModel model)
        {
            bool fileSize = false;

            try
            {
                if (model.FileUploadList != null && model.FileUploadList.Any())
                {
                    foreach (HttpPostedFileBase f in model.FileUploadList)
                    {
                        if (f != null && f.ContentLength > 2097152)
                        {
                            fileSize = true;
                            break;
                        }
                    }
                    if (fileSize) //server side check
                    {
                        ViewData.ModelState.AddModelError("FileSize", "Cannot upload files greater than 2MB.");
                    }
                    else
                    {
                        AddAttachedFiles(model);
                    }
                }
                //var result = GenerateRequestDrivenEmail(model, Prototype.WebUI.Models.Enumumerations.RequestServiceType.DocumentsUploaded);

                return RedirectToAction("Confirmation");
            }
            catch (Exception ex)
            {
                // error logging here...
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                model.CustomerReference = "An error occured uploading files";
                return View("DocumentUpload", model);
            }
        }

        
        //[HttpPost]
        //[HttpParamAction]
        //[ActionName("DocumentUpload")]
        //public ActionResult SendByMail(FileUploadModel model)
        //{
            // action method used for multiple form submit buttons
            //model.DocumentSendMethod = Prototype.WebUI.Models.Enumumerations.SupportingDocumentDeliveryType.Mail;
            //Session["DocumentSendMethod"] = model.DocumentSendMethod.ToString();

            //if (model.ParentRequestId > 0)
            //{
            //    UpdateParentRequest(model);
            //    return GenerateRequestDrivenEmail(model, Prototype.WebUI.Models.Enumumerations.RequestServiceType.DocumentSendOffline);
            //}
            //else
            //{
            //    string error = "No Known request available";
            //    return Json(new { IsValid = false, Error = error });
            //}
        //}

        
        //[HttpPost]
        //[HttpParamAction]
        //[ActionName("DocumentUpload")]
        //public ActionResult Resume(FileUploadModel model)
        //{
        // action method used for multiple form submit buttons

        //    model.DocumentSendMethod = SupportingDocumentDeliveryType.Unknown;
        //    Session["DocumentSendMethod"] = model.DocumentSendMethod.ToString();

        //    if (model.ParentRequestId > 0)
        //    {
        //        UpdateParentRequest(model);
        //        return GenerateRequestDrivenEmail(model, RequestServiceType.SendDocumentUploadResumeEmail);
        //    }
        //    else
        //    {
        //        string error = "No Known request available";
        //        return Json(new { IsValid = false, Error = error });
        //    }
        //}

        #endregion

        #region Private Methods

        private void AddAttachedFiles(FileUploadModel model)
        {
            int fileId = 0;
            int counter = 0;
            var a = Enumumerations.AttachmentType.OfficialBodyDocument;
            IEnumerable<HttpPostedFileBase> files = model.FileUploadList;
            var fileUploadResponseList = new List<FileUploadResponse>();

            if (files != null && files.Count() > 0)
            {
                // hit the svc or logic layer here:
                //using (PublicRequestClient client = new PublicRequestClient(Properties.Settings.Default.PublicRequestClientEndPoint))
                //{
                using (var customerLL = new CustomerLL(mapper)) // Usually call a service here ..
                {

                    foreach (HttpPostedFileBase file in files)
                    {
                        counter++;
                        if (counter <= 2) //only 2 uploads allowed
                        {
                            var data = new byte[file.ContentLength];
                            file.InputStream.Read(data, 0, file.ContentLength);
                            string contentType = file.ContentType;
                            string originalFileName = file.FileName;

                            //service/bl layer...should be the VI request
                            fileId = customerLL.AddAttachedFileAsBytes(counter, a, contentType, originalFileName, data);

                            if (fileId > 0)
                            {
                                FileUploadResponse fileUploadResponse = new FileUploadResponse()
                                {
                                    FileID = fileId,
                                    FileName = originalFileName
                                };
                                fileUploadResponseList.Add(fileUploadResponse);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                model.FileUploadResponses = fileUploadResponseList;
                model.FileUploadList = null;
                model.FilesToUpload = 0;
                //}
            }
        }

        //private ActionResult GenerateRequestDrivenEmail(FileUploadModel model, RequestServiceType requestServiceType)
        //{
        //    List<ValidationError> errors = new List<ValidationError>();
        //    RequestStatus status = RequestStatus.Abandoned;
        //    string customerReference = String.Empty;
        //    bool isSuccess = false;
        //    string errorMsg = string.Empty;

        //    //the parent request id is the order or id check request
        //    Request request = new Request()
        //    {
        //        RequestServiceType = requestServiceType,
        //        LoginName = CurrentUser.EmailAddress,
        //        ParentRequestId = model.ParentRequestId,
        //        SupportingDocumentDeliveryType = model.DocumentSendMethod,
        //        ReportDeliveryType = null,
        //        Status = RequestStatus.Pending,
        //        SkipValidation = true
        //    };

        //    try
        //    {
        //        using (PublicRequestClient client = new PublicRequestClient(Properties.Settings.Default.PublicRequestClientEndPoint))
        //        {
        //            if (client.State == CommunicationState.Faulted)
        //            {
        //                client.Abort();
        //                throw new Exception(ClientCommunicationFaultedException);
        //            }
        //            if (request != null)
        //            {
        //                status = client.SubmitAccountSecurityRequest(out errors, out customerReference, request);
        //                if (errors.Any())
        //                {
        //                    TempData["error"] = new Exception(string.Format("{0} {1}", errors.Select(e => e.Message.ToString().FirstOrDefault()), ContactPacMessage));
        //                    BuildValidationErrorList(errors);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        //        return Json(new { IsValid = false, Error = UnexpectedErrorMessage });
        //    }

        //    return Json(new { IsSuccess = isSuccess, Status = status, Errors = errors });

        //}

        #endregion

    }
}
