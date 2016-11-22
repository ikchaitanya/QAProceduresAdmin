using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jord.ACHEQA.DAL;
using Jord.ACHEQA.Entities;

namespace Jord.ACHEQA.BAL
    {
  public static   class cls_Lookup_BAL
        {
      public static DataTable Get_LookupCategories_BAL()
          {
          try
              {
              cls_Lookup_DAL  objdal = new cls_Lookup_DAL();
              return objdal.Get_LookupCategories_DAL(); 

              }
          catch (Exception ex)
              {
              return null;
              throw new Exception(ex.Message);
              }
          }
      public static DataTable Get_LookupValues_BAL(int LcatID)
          {
          try
              {
              cls_Lookup_DAL objdal = new cls_Lookup_DAL();
              return objdal.Get_LookupValues_DAL (LcatID ); 
              }
          catch (Exception ex)
              {
              return null;
              throw new Exception(ex.Message);
              }
          }
      public static string  Save_LookupCategiries_BAL(LookupCategory_Entity objEntity)
          {
          try
              {
              cls_Lookup_DAL objdal = new cls_Lookup_DAL();
              return objdal.Save_LookupCategiries_DAL(objEntity);
              }
          catch (Exception ex)
              {
              
             
              throw new Exception(ex.Message) ;
              }
          }
      public static string  Save_LookupValues_BAL(LookupValue_Entity  objEntity)
          {
          try
              {
              cls_Lookup_DAL objdal = new cls_Lookup_DAL();
              return objdal.Save_LookupValues_DAL (objEntity);
              }
          catch (Exception ex)
              {

              //return 0;
              throw new Exception(ex.Message);
              }

          }
        }
    }
