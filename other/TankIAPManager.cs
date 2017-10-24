using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.GameFramework;


namespace com.fanxing.Manager
{
	public class TankIAPManager : ManagerBase, IStoreListener 
	{

		private IStoreController m_StoreController = null; // The Unity Purchasing system.
		private IExtensionProvider m_StoreExtensionProvider = null; // The store-specific Purchasing subsystems.
		//private IAppleExtensions appleExtensions;




		// Product identifiers for all products capable of being purchased: 
		// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
		// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
		// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

		// General product identifiers for the consumable, non-consumable, and subscription products.
		// Use these handles in the code to reference which product to purchase. Also use these values 
		// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
		// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
		// specific mapping to Unity Purchasing's AddProduct, below.
		public static string kProductIDConsumable =    "consumable";   
		public static string kProductIDNonConsumable = "nonconsumable";
		public static string kProductIDSubscription =  "subscription"; 

		// Apple App Store-specific product identifier for the subscription product.
		private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";

		// Google Play Store-specific product identifier subscription product.
		private static string kProductNameGooglePlaySubscription =  "com.unity3d.subscription.original"; 


		public TankIAPManager()
		{
			// If we haven't set up the Unity Purchasing reference
			if (m_StoreController == null)
			{
				// Begin to configure our connection to Purchasing
				InitializePurchasing();
			}
		}
			
		public void InitializePurchasing()
		{
			// If we have already connected to Purchasing ...
			if (IsInitialized())
			{
				// ... we are done here.
				return;
			}

			// Create a builder, first passing in a suite of Unity provided stores.
			var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
			builder.AddProduct("100_gold_coins", ProductType.Consumable, new IDs
				{
					{"100_gold_coins_google", GooglePlay.Name},
					{"100_gold_coins_mac", MacAppStore.Name}
				});


			// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
			// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
			UnityPurchasing.Initialize(this, builder);
			
		}


		private bool IsInitialized()
		{
			// Only say we are initialized if both the Purchasing references are set.
			return m_StoreController != null && m_StoreExtensionProvider != null;
		}

		//  
		// --- IStoreListener
		//

		/// <summary>
		/// Called when Unity IAP is ready to make purchases.
		/// </summary>
		public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
		{
			// Purchasing has succeeded initializing. Collect our Purchasing references.
			Debug.Log("OnInitialized: PASS");

			// Overall Purchasing system, configured with products for this application.
			this.m_StoreController = controller;
			// Store specific subsystem, for accessing device-specific store features.
			this.m_StoreExtensionProvider = extensions;
		}
			
		/// <summary>
		/// Called when Unity IAP encounters an unrecoverable initialization error.
		///
		/// Note that this will not be called if Internet is unavailable; Unity IAP
		/// will attempt initialization until it becomes available.
		/// </summary>
		public void OnInitializeFailed (InitializationFailureReason error)
		{

			// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
			Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);

			foreach (var product in m_StoreController.products.all) 
			{
				Debug.Log (product.metadata.localizedTitle);
				Debug.Log (product.metadata.localizedDescription);
				Debug.Log (product.metadata.localizedPriceString);
			}
		}



		////////////////////////
		/// 
		/// 购买
		/// 
		/// ////////////////////
		/// 
		/// 
		// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
		// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
		public void RestorePurchases()  
		{  
			if (!IsInitialized())  
			{  
				Debug.Log("RestorePurchases FAIL. Not initialized.");  
				return;  
			}  
			if (Application.platform == RuntimePlatform.IPhonePlayer ||   
				Application.platform == RuntimePlatform.OSXPlayer)  
			{  
				Debug.Log("RestorePurchases started ...");  
				var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();  
				apple.RestoreTransactions((result) => {  
					//返回一个bool值，如果成功，则会多次调用支付回调，然后根据支付回调中的参数得到商品id，最后做处理(ProcessPurchase)  
					Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");  
				});  
			}  
			else  
			{  
				Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);  
			}  
		}

		// Example method called when the user presses a 'buy' button
		// to start the purchase process.
		public void OnPurchaseClicked(string productId) 
		{
			//m_StoreController.InitiatePurchase(productId);

			if (IsInitialized())  
			{  
				Product product = m_StoreController.products.WithID(productId);  
				if (product != null && product.availableToPurchase)  
				{  
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));  
					m_StoreController.InitiatePurchase(product);  
				}  
				else  
				{  
					Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");  
				}  
			}  
			else  
			{  
				Debug.Log("BuyProductID FAIL. Not initialized.");  
			}  
		}

		/// <summary>
		/// Called when a purchase fails.
		/// </summary>
		public void OnPurchaseFailed (Product i, PurchaseFailureReason p)
		{
			// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
			// this reason with the user to guide their troubleshooting actions.
			Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", i.definition.storeSpecificId, p));
		}

		/// <summary>
		/// Called when a purchase completes.
		///
		/// May be called at any time after OnInitialized().
		/// </summary>
		public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs args)
		{

			// A consumable product has been purchased by this user.
			if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
				//ScoreManager.score += 100;
			}
			// Or ... a non-consumable product has been purchased by this user.
			else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				// TODO: The non-consumable item has been successfully purchased, grant this item to the player.
			}
			// Or ... a subscription product has been purchased by this user.
			else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				// TODO: The subscription item has been successfully purchased, grant this to the player.
			}
			// Or ... an unknown product has been purchased by this user. Fill in additional products here....
			else 
			{
				Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			}

			// Return a flag indicating whether this product has completely been received, or if the application needs 
			// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
			// saving purchased products to the cloud, and when that save is delayed. 




			//return PurchaseProcessingResult.Complete;
			return PurchaseProcessingResult.Pending;



		}


		public void OnConfirmPendingPurchase(string productId) 
		{

			Product product = m_StoreController.products.WithID(productId);  
			if (product != null && product.availableToPurchase)  
			{  
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));  
			

				m_StoreController.ConfirmPendingPurchase (product);
			}  
			else  
			{  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");  
			}  

			
		}



	}

}
