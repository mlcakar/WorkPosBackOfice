﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using WorkPosDb.EntityFrameWork;
using ComboBox = DevExpress.XtraEditors.ComboBox;

namespace WorkPosBackOfice.ModulObject
{
    public class ModelObjects
    {

        public string Connstring { get; set; }
        private readonly WorkPosDbContext _dbproductContext;
        DataSet ds;
        public ModelObjects(string connstring)
        {
            this.Connstring = connstring;
            _dbproductContext = new WorkPosDbContext();
        }

        public void ObjeIslemler2(ObjectEnum objectEnum,ObjectIslem objectIslem,object obje,int iliskiliObjeId,GridControl gridControl)
        {

            switch (objectEnum)
            {
                case ObjectEnum.Marka:
                    var brand = (DataRowView) obje;
                    PRODUCT_BRANDS productBrand;
                    BindingSource bi=new BindingSource();
                    switch (objectIslem)
                            {
                               
                                case ObjectIslem.Ekle:
                                         /*  productBrand = new PRODUCT_BRANDS
                                           {
                                               BRAND_NAME = (string) brand["Marka"]
                                            };
                                          _dbproductContext.PRODUCT_BRANDS.Add(productBrand);
                       */
                                            
                                          _dbproductContext.SaveChanges();
                                            break;
                                case ObjectIslem.Guncelle:
                                    int id = (int) brand["Id"];
                                        productBrand = _dbproductContext.PRODUCT_BRANDS.FirstOrDefault(b => b.BRAND_ID ==id );
                                        productBrand.BRAND_NAME = brand["Marka"].ToString();
                                        _dbproductContext.Entry(productBrand).State = System.Data.Entity.EntityState.Modified;
                                        _dbproductContext.SaveChanges();
                                        break;
                                    case ObjectIslem.Listele:
                            
                                        _dbproductContext.PRODUCT_BRANDS.Load();
            // This line of code is generated by Data Source Configuration Wizard

                                    bi.DataSource = _dbproductContext.PRODUCT_BRANDS.Local.ToBindingList();
                                        gridControl.DataSource = bi;
                                      /*  List<MyGridView> objeList = (from pbs in _dbproductContext.PRODUCT_BRANDS
                                                                      select new MyGridView()
                                                                 {
                                                                     Id= pbs.BRAND_ID,Deger = pbs.BRAND_NAME,
                                                                     kolonAdi = ObjectEnum.Marka.ToString()
                                                                 }
                                           ).ToList();
                                        
                                     ds = new DataSet();
                                    ds.Tables.Add(GetDataSource(objeList));
                                    gridControl.DataSource = ds.Tables[0];*/
                                    break;
                            }
                    break;
                case ObjectEnum.Model:
                    var model = (DataRowView)obje;
                    PRODUCT_BRANDS_MODEL productBrandsModel;
                            switch (objectIslem)
                            {

                                case ObjectIslem.Ekle:
                                    productBrandsModel = new PRODUCT_BRANDS_MODEL { BRAND_ID = iliskiliObjeId,MODEL_NAME =(string)model[objectEnum.ToString()]};
                                    _dbproductContext.PRODUCT_BRANDS_MODEL.Add(productBrandsModel);
                                    _dbproductContext.SaveChanges();
                                    break;
                                case ObjectIslem.Guncelle:
                                    int id = (int)model["Id"];
                                    productBrandsModel = _dbproductContext.PRODUCT_BRANDS_MODEL.FirstOrDefault(b => b.MODEL_ID == id);
                                    productBrandsModel.MODEL_NAME = model[objectEnum.ToString()].ToString();

                                    _dbproductContext.Entry(productBrandsModel).State = System.Data.Entity.EntityState.Modified;
                                    _dbproductContext.SaveChanges();
                                    break;
                                case ObjectIslem.Listele:
                                    _dbproductContext.PRODUCT_BRANDS.Load();
            // This line of code is generated by Data Source Configuration Wizard
                                   
                                    gridControl.DataSource = _dbproductContext.PRODUCT_BRANDS.Local.ToBindingList();
                                    List<MyGridView> objeList = (from pbs in _dbproductContext.PRODUCT_BRANDS_MODEL
                                                                 select new MyGridView()
                                                             {
                                                                // Id = pbs.BRAND_ID,
                                                                 Id = pbs.MODEL_ID,
                                                                 Deger = pbs.MODEL_NAME,
                                                                 kolonAdi = objectEnum.ToString()
                                                             }
                                       ).ToList();
                                      ds = new DataSet();
                                    ds.Tables.Add(GetDataSource(objeList));
                                    gridControl.DataSource = ds.Tables[0];
                                    break;
                    }
                    break;
                case ObjectEnum.Birim:
                         var birim = (Birim) obje;
                    SETUP_UNIT setupUnit;
                            switch (objectIslem)
                            {

                                case ObjectIslem.Ekle:
                                    setupUnit = new SETUP_UNIT { UNIT_ID = birim.BirimId,UNIT =birim.BirimAd};
                                    _dbproductContext.SETUP_UNIT.Add(setupUnit);
                                    _dbproductContext.SaveChanges();
                                    break;
                                case ObjectIslem.Guncelle:
                                    setupUnit = _dbproductContext.SETUP_UNIT.FirstOrDefault(b => b.UNIT_ID == birim.BirimId);
                                    setupUnit.UNIT = birim.BirimAd;

                                    _dbproductContext.Entry(setupUnit).State = System.Data.Entity.EntityState.Modified;
                                    _dbproductContext.SaveChanges();
                                    break;
                                case ObjectIslem.Listele:
                                    List<Birim> objeList = (from pbs in _dbproductContext.SETUP_UNIT
                                                             select new Birim()
                                                             {
                                                                 BirimId = pbs.UNIT_ID,
                                                                 BirimAd = pbs.UNIT
                                                             }
                                       ).ToList();
                                    var bindingSource = new BindingSource(objeList, null);
                                    gridControl.DataSource = bindingSource;
                                    break;
                    }
                    break;
                case ObjectEnum.UrunKategori:
                    var productCat_ = (UrunKategori)obje;
                    PRODUCT_CAT productCat;
                    switch (objectIslem)
                    {

                        case ObjectIslem.Ekle:
                            productCat = new PRODUCT_CAT { PRODUCT_CATID =productCat_.KategoriId, PRODUCT_CAT1 =productCat_.Kategori,HIERARCHY = productCat_.KategoriKodu};
                            _dbproductContext.PRODUCT_CAT.Add(productCat);
                            _dbproductContext.SaveChanges();
                            break;
                        case ObjectIslem.Guncelle:
                            productCat = _dbproductContext.PRODUCT_CAT.FirstOrDefault(b => b.PRODUCT_CATID == productCat_.KategoriId);
                            productCat.PRODUCT_CAT1 = productCat_.Kategori;
                            productCat_.Hiyerarsi = productCat_.Hiyerarsi;

                            _dbproductContext.Entry(productCat).State = System.Data.Entity.EntityState.Modified;
                            _dbproductContext.SaveChanges();
                            break;
                        case ObjectIslem.Listele:
                            List<UrunKategori> objeList = (from pbs in _dbproductContext.PRODUCT_CAT
                                                           select new UrunKategori()
                                                         {
                                                             KategoriId = pbs.PRODUCT_CATID,
                                                             Kategori = pbs.PRODUCT_CAT1,
                                                             KategoriKodu = pbs.HIERARCHY
 
                                                         }
                               ).ToList();
                            var bindingSource = new BindingSource(objeList, null);
                            gridControl.DataSource = bindingSource;
                            break;
                    }
                    break;
                    
            }

          
        }

        public void ObjeIslemler(ObjectEnum objectEnum, ObjectIslem objectIslem, object obje, int iliskiliObjeId,
            GridControl gridControl)
        {
            switch (objectEnum)
            {
                    
            }
        }

        private DataTable GetDataSource(List<MyGridView> markaList)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));

            for (int i = 0; i < markaList.Count; i++)
            {if(i==0)
                dt.Columns.Add(markaList[i].kolonAdi, typeof(string));
            dt.Rows.Add(markaList[i].Id, markaList[i].Deger);
            }
            return dt;
        }

       
        public void ComboDoldur(ObjectEnum objectEnum,object obje)
        {
            
        }
       
        public void ErrorMessage(string message,int tip)
        {
            switch (tip)
            {
                case 0:
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            
        }

        public class Brand
        {
            [Key]
            public int MarkaId { get; set; }
            public string Marka { get; set; }
        }

        public class MyGridView
        {
            [Key]
            public int Id { get; set; }
            public string Deger { get; set; }

            public string kolonAdi { get; set; }
        }

        public class Birim
        {
            public int BirimId { get; set; }
            public string BirimAd { get; set; }
        }
     

        public class UrunKategori
        {
            public int KategoriId { get; set; }
            public string Kategori { get; set; }
            public string KategoriKodu { get; set; }
      
            public string Hiyerarsi { get; set; }
        }

      

        public class Model
        {
            public int? MarkaId { get; set; }
            public string ModelName { get; set; }
            public int ModelId { get; set; }
        }

        public enum ObjectEnum
        {
            Marka,
            Model,
            Birim,
            UrunKategori
        }
        public enum ObjectIslem
        {
            Ekle,
            Guncelle,
            Listele
        }



     
    }

    
}
