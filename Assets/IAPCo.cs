using System;
using UnityEngine;
using System.Linq;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

namespace Assets.Scripts.Utils
{
    public class IAPCo : MonoBehaviour, IStoreListener
    {
        private const string ProductIdHero = "hero";
        public static IAPCo I;
        IStoreController _controller;
        IExtensionProvider _extensions;

        private void Start()
        {
            I = this;
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, ProductCatalog.LoadDefaultCatalog());
            //_productId = "disable_ads";
            //builder.AddProduct(_productId, ProductType.NonConsumable);
            UnityPurchasing.Initialize(this, builder);
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            _extensions = extensions;
            //Debug.LogWarning("OnInitialized: " + controller.products.all
            //    .Select(x => x.definition.id).ToStringJoin());
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError("OnInitializeFailed: " + error);
        }

        public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
        {
            Debug.LogError($"OnPurchaseFailed: {p} ({i})"); //.ToStringAll()
        }

        //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
        //{
        //    this.LogMe($"ProcessPurchase: {e.purchasedProduct.ToStringAll()} {e.purchasedProduct.metadata.ToStringAll()}");
        //    // UnityEngine.Purchasing.Security
        //    ServerController.Game.SendIAP(e.purchasedProduct.definition.id);
        //    return PurchaseProcessingResult.Complete; // todo Pending
        //    //_controller.ConfirmPendingPurchase();
        //}

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
        {
            var product = e.purchasedProduct;
            Debug.Log($"ProcessPurchase: {e.purchasedProduct.definition.id}");
            #region todo доделать безопасность
            #region UsingHolders
#pragma warning disable CS0168 // Переменная объявлена, но не используется
            IAPSecurityException toHoldUsing;
            Math.Abs(0);
#pragma warning restore CS0168 // Переменная объявлена, но не используется 
            #endregion
            //#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
            //            var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            //                AppleTangle.Data(), Application.identifier);
            //            try
            //            {
            //                var result = validator.Validate(e.purchasedProduct.receipt);
            //                Debug.Log("Receipt is valid. Contents:");
            //                foreach (var productReceipt in result)
            //                {
            //                    Debug.Log(productReceipt.productID);
            //                    Debug.Log(productReceipt.purchaseDate);
            //                    Debug.Log(productReceipt.transactionID);
            //                }
            //            }
            //            catch (IAPSecurityException ex)
            //            {
            //                Debug.Log("Invalid receipt, not unlocking content " + ex);
            //                return PurchaseProcessingResult.Complete;
            //            }
            //#endif 
            #endregion

            //if (ProductIdHero == e.purchasedProduct.definition.id)
            //    ServerController.Game.SendIAP(_pers);
            //else ServerController.Game.SendIAP(_item);
            //ServerController.Game.OnOkIAP = () => _controller.ConfirmPendingPurchase(product);
            ////StartCoroutine(DoPurchase(product));
            //ServerController.Game.OnOkIAP.Invoke(); // todo
            return PurchaseProcessingResult.Complete;
        }

        //EShopItem _item;
        //EMob _pers;
        public void StartBuy(string id)
        {
            //_item = item;
            //var id = item.ToPurchaise();
            //Log.ActualInfo("StartBuy: " + id);
            _controller.InitiatePurchase(id);
        }
        //public void StartBuy(EMob pers)
        //{
        //    _pers = pers;
        //    Log.ActualInfo("StartBuy: " + pers);
        //    _controller.InitiatePurchase(ProductIdHero);
        //}
    }
}