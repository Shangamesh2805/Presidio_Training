﻿using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem item = GetByKey(key);
            if (item == null)
            {
                items.Remove(item);
                return item;
            }
            else
            {
                throw new NoCartItemWithGivenIDException();
            }
        }

        public override CartItem GetByKey(int key) {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].CartId == key)
                    return items[i];
            
            }

                throw new NoCartItemWithGivenIDException();
            
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartitem=GetByKey(item.CartId);
            if (cartitem != null)
            {

                cartitem = item;
                return cartitem;
            }
            else
            {
                throw new NoCartItemWithGivenIDException();

            }
            
        }
    }
}
