﻿using System;

namespace Mx.NET.SDK.Configuration
{
    public class ApiNetworkConfiguration
    {
        public Network Network { get; }
        public Uri APIUri { get; }
        public Uri ExplorerUri { get; set; }
        public Uri WebWalletUri { get; set; }
        public Uri XAliasWalletUri { get; set; }

        /// <summary>
        /// Default MultiversX API network configuration
        /// </summary>
        /// <param name="network">MainNet/DevNet/TestNet</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ApiNetworkConfiguration(Network network)
        {
            Network = network;
            switch (network)
            {
                case Network.MainNet:
                    APIUri = new Uri("https://api.multiversx.com/");
                    ExplorerUri = new Uri("https://explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://xalias.com/");
                    break;
                case Network.DevNet:
                    APIUri = new Uri("https://devnet-api.multiversx.com/");
                    ExplorerUri = new Uri("https://devnet-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://devnet-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://devnet.xalias.com/");
                    break;
                case Network.OldDevNet:
                    APIUri = new Uri("https://devnet-old-gateway.multiversx.com/");
                    ExplorerUri = new Uri("https://devnet-old-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://devnet-old-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://devnet-old.xalias.com/");
                    break;
                case Network.TestNet:
                    APIUri = new Uri("https://testnet-api.multiversx.com/");
                    ExplorerUri = new Uri("https://testnet-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://testnet-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://testnet.xalias.com/");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(network), network, null);
            }
        }

        /// <summary>
        /// Custom API network configuration
        /// </summary>
        /// <param name="network">MainNet/DevNet/TestNet</param>
        /// <param name="apiUri">API custom Uri</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ApiNetworkConfiguration(Network network, Uri apiUri)
        {
            Network = network;
            APIUri = apiUri;

            switch (network)
            {
                case Network.MainNet:
                    ExplorerUri = new Uri("https://explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://xalias.com/");
                    break;
                case Network.DevNet:
                    ExplorerUri = new Uri("https://devnet-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://devnet-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://devnet.xalias.com/");
                    break;
                case Network.OldDevNet:
                    ExplorerUri = new Uri("https://devnet-old-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://devnet-old-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://devnet-old.xalias.com/");
                    break;
                case Network.TestNet:
                    ExplorerUri = new Uri("https://testnet-explorer.multiversx.com/");
                    WebWalletUri = new Uri("https://testnet-wallet.multiversx.com/");
                    XAliasWalletUri = new Uri("https://testnet.xalias.com/");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(network), network, null);
            }
        }
    }
}
