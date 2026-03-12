using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- TA3MEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- TA3mem --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3mem")
                .Where(CriteriaSet.And().In("TA3mem", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3cfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3cfg")
                .Where(CriteriaSet.And().In("TA3cfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3lstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3lstusr")
                .Where(CriteriaSet.And().In("TA3lstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3lstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3lstcol")
                .Where(CriteriaSet.And().In("TA3lstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3lstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3lstren")
                .Where(CriteriaSet.And().In("TA3lstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3usrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3usrwid")
                .Where(CriteriaSet.And().In("TA3usrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3usrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3usrcfg")
                .Where(CriteriaSet.And().In("TA3usrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3usrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3usrset")
                .Where(CriteriaSet.And().In("TA3usrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3wkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3wkfact")
                .Where(CriteriaSet.And().In("TA3wkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3wkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3wkfcon")
                .Where(CriteriaSet.And().In("TA3wkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3wkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3wkflig")
                .Where(CriteriaSet.And().In("TA3wkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3wkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3wkflow")
                .Where(CriteriaSet.And().In("TA3wkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3notifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3notifi")
                .Where(CriteriaSet.And().In("TA3notifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3prmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3prmfrm")
                .Where(CriteriaSet.And().In("TA3prmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3scrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3scrcrd")
                .Where(CriteriaSet.And().In("TA3scrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3postit --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3postit")
                .Where(CriteriaSet.And().In("TA3postit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3alerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3alerta")
                .Where(CriteriaSet.And().In("TA3alerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3altent --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3altent")
                .Where(CriteriaSet.And().In("TA3altent", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3talert --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3talert")
                .Where(CriteriaSet.And().In("TA3talert", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3delega --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3delega")
                .Where(CriteriaSet.And().In("TA3delega", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3TABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3TABDINAMIC")
                .Where(CriteriaSet.And().In("TA3TABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3altran --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3altran")
                .Where(CriteriaSet.And().In("TA3altran", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3workflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3workflowtask")
                .Where(CriteriaSet.And().In("TA3workflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- TA3workflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("TA3workflowprocess")
                .Where(CriteriaSet.And().In("TA3workflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}