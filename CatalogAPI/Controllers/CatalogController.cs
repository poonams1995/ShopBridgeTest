using CatalogAPI.Database;
using CatalogAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _ctx;

        public CatalogController(CatalogContext ctx)
        {
            _ctx = ctx;
        }

        #region ---Unit Master Methods---
        [HttpGet("GetUnitMaster")]
        public async Task<ResponseModel> GetUnits() {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.ResponseData = _ctx.UnitMaster.Where(unit=>unit.IsDeleted==false).ToList();
                responseModel.ResponseCode = 200;
                responseModel.ResponseMessage = "Unit Master Details Fetched Successfully!";
                return responseModel;

            }
            catch (Exception)
            {

                responseModel.ResponseData = null;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = "Oops!Error in getting Unit Master Details";
                return responseModel;
            }
        }

        [HttpPost("AddUnitMaster")]
        public async Task<ResponseModel> AddUnitMaster(UnitMaster unitMaster) {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid) {
                    _ctx.UnitMaster.Add(unitMaster);
                    await _ctx.SaveChangesAsync();
                    responseModel.ResponseData = unitMaster.Id;
                    responseModel.ResponseCode = 201;//Created
                    responseModel.ResponseMessage = "Unit Master Added Successfully";
                    return responseModel;
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Unit Master Model is Not Valid";
                    return responseModel;

                }

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = unitMaster.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("UpdateUnitMaster")]
        public async Task<ResponseModel> UpdateUnitMaster(UnitMaster unitMaster)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.UnitMaster.Where(unit => unit.Id == unitMaster.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.UnitName = unitMaster.UnitName;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = unitMaster.ModifiedBy;


                        _ctx.UnitMaster.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created
                        responseModel.ResponseMessage = "Unit Master Updated Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Unit Master Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = unitMaster.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("DeleteUnitMaster")]
        public async Task<ResponseModel> DeleteUnitMaster(UnitMaster unitMaster)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.UnitMaster.Where(unit => unit.Id == unitMaster.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.IsDeleted = true;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = unitMaster.ModifiedBy;


                        _ctx.UnitMaster.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created  
                        responseModel.ResponseMessage = "Unit Master Added Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Unit Master Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = unitMaster.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        #endregion

        #region ---Category Methods---

        [HttpGet("GetCategories")]
        public async Task<ResponseModel> GetCategories()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.ResponseData = _ctx.Categories.Where(ctg => ctg.IsDeleted == false).ToList();
                responseModel.ResponseCode = 200;
                responseModel.ResponseMessage = "Category Details Fetched Successfully!";
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = null;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = "Oops! Error in getting category Details";
                return responseModel;
            }
        }

        [HttpPost("AddCategory")]
        public async Task<ResponseModel> AddCategory(Category category)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Categories.Add(category);
                    await _ctx.SaveChangesAsync();
                    responseModel.ResponseData = category.Id;
                    responseModel.ResponseCode = 201;//Created
                    responseModel.ResponseMessage = "Category Added Successfully";
                    return responseModel;
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Category Model is Not Valid";
                    return responseModel;

                }

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = category.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<ResponseModel> UpdateCategory(Category category)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.Categories.Where(ctg => ctg.Id == ctg.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.CategoryName = category.CategoryName;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = category.ModifiedBy;


                        _ctx.Categories.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created
                        responseModel.ResponseMessage = "Category Updated Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Category Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = category.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("DeleteCategory")]
        public async Task<ResponseModel> DeleteCategory(Category category)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.Categories.Where(ctg => ctg.Id == category.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.IsDeleted = true;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = category.ModifiedBy;


                        _ctx.Categories.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created  
                        responseModel.ResponseMessage = "Category deleted Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Unit Master Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = category.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        #endregion

        #region ---Catalog Methods ---
        [HttpGet("GetCatalogs")]
        public async Task<ResponseModel> GetCatalogs()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.ResponseData = (from ctlg in _ctx.Catalogs
                                              join ctg in _ctx.Categories
                                              on ctlg.CategoryId equals ctg.Id
                                              join unt in _ctx.UnitMaster
                                              on ctlg.UnitId equals unt.Id
                                              where ctlg.IsDeleted==false
                                              select new CatalogModel
                                              {
                                                  Id=ctlg.Id,
                                                  CatalogName=ctlg.CatalogName,
                                                  CategoryId=ctlg.CategoryId,
                                                  UnitId=ctlg.UnitId,
                                                  IsAvailable=ctlg.IsAvailable,
                                                  IsInStock=ctlg.IsInStock,
                                                  SellingPrice=ctlg.SellingPrice,
                                                  CreatedBy=ctlg.CreatedBy,
                                                  CreatedOn=ctlg.CreatedOn,
                                                  UnitName=unt.UnitName,
                                                  CategoryName=ctg.CategoryName

                                              }).ToList();
                responseModel.ResponseCode = 200;
                responseModel.ResponseMessage = "Catalog Details Fetched Successfully!";
                return responseModel;

            }
            catch (Exception)
            {

                responseModel.ResponseData = null;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = "Oops!Error in getting catalog Details";
                return responseModel;
            }
        }

        [HttpPost("AddCatalog")]
        public async Task<ResponseModel> AddCatalog(Catalog catalog)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Catalogs.Add(catalog);
                    await _ctx.SaveChangesAsync();
                    responseModel.ResponseData = catalog.Id;
                    responseModel.ResponseCode = 201;//Created
                    responseModel.ResponseMessage = "Catalog Added Successfully";
                    return responseModel;
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Catalog Model is Not Valid";
                    return responseModel;

                }

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = catalog.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("UpdateCatalog")]
        public async Task<ResponseModel> UpdateCatalog(Catalog catalog)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.Catalogs.Where(ctlg => ctlg.Id == catalog.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.CatalogName = catalog.CatalogName;
                        objToBeUpdate.CategoryId = catalog.CategoryId;
                        objToBeUpdate.UnitId = catalog.UnitId;
                        objToBeUpdate.SellingPrice = catalog.SellingPrice;
                        objToBeUpdate.Description = catalog.Description;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = catalog.ModifiedBy;
                        objToBeUpdate.IsAvailable = catalog.IsAvailable;
                        objToBeUpdate.IsInStock = catalog.IsInStock;

                        _ctx.Catalogs.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created
                        responseModel.ResponseMessage = "Catalog Updated Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Catalog Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = catalog.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("DeleteCatalog")]
        public async Task<ResponseModel> DeleteCatalog(Catalog catalog)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var objToBeUpdate = _ctx.Catalogs.Where(ctlg => ctlg.Id == catalog.Id).FirstOrDefault();
                    if (objToBeUpdate != null)
                    {
                        objToBeUpdate.IsDeleted = true;
                        objToBeUpdate.ModifiedOn = DateTime.Now;
                        objToBeUpdate.ModifiedBy = catalog.ModifiedBy;


                        _ctx.Catalogs.Update(objToBeUpdate);
                        await _ctx.SaveChangesAsync();
                        responseModel.ResponseData = objToBeUpdate.Id;
                        responseModel.ResponseCode = 201;//Created  
                        responseModel.ResponseMessage = "Catalog deleted Successfully";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Catalog Model is Not Valid";
                    return responseModel;

                }
                return responseModel;

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = catalog.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPost("AddCatalogAttachment")]
        public async Task<ResponseModel> AddCatalogAttachment(CatalogAttachments catalog)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.CatalogAttachments.Add(catalog);
                    await _ctx.SaveChangesAsync();
                    responseModel.ResponseData = catalog.Id;
                    responseModel.ResponseCode = 201;//Created
                    responseModel.ResponseMessage = "Catalog Attachment Added Successfully";
                    return responseModel;
                }
                else
                {
                    responseModel.ResponseData = ModelState.ErrorCount;
                    responseModel.ResponseCode = 406;   //Not Acceptable
                    responseModel.ResponseMessage = "Catalog Attachment Model is Not Valid";
                    return responseModel;

                }

            }
            catch (Exception ex)
            {

                responseModel.ResponseData = catalog.Id;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpGet("GetCatalogById/{id}")]
        public async Task<ResponseModel> GetCatalogById(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.ResponseData = (from ctlg in _ctx.Catalogs
                                              join ctg in _ctx.Categories
                                              on ctlg.CategoryId equals ctg.Id
                                              join unt in _ctx.UnitMaster
                                              on ctlg.UnitId equals unt.Id
                                              where ctlg.Id == id
                                              select new CatalogModel
                                              {
                                                  Id = ctlg.Id,
                                                  CatalogName = ctlg.CatalogName,
                                                  CategoryId = ctlg.CategoryId,
                                                  UnitId = ctlg.UnitId,
                                                  IsAvailable = ctlg.IsAvailable,
                                                  IsInStock = ctlg.IsInStock,
                                                  SellingPrice = ctlg.SellingPrice,
                                                  CreatedBy = ctlg.CreatedBy,
                                                  CreatedOn = ctlg.CreatedOn,
                                                  UnitName = unt.UnitName,
                                                  CategoryName = ctg.CategoryName

                                              });
                responseModel.ResponseCode = 200;
                responseModel.ResponseMessage = "Catalog Details Fetched Successfully!";
                return responseModel;

            }
            catch (Exception)
            {

                responseModel.ResponseData = null;
                responseModel.ResponseCode = 400;
                responseModel.ResponseMessage = "Oops!Error in getting catalog Details";
                return responseModel;
            }
        }

        #endregion
    }
}
