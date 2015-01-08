package io.github.leedscodedojo;

import java.util.*;

public class Basket {
    List<String> items = new ArrayList<String>();

    static Map<String, Integer> products = new HashMap<String, Integer>();

    static {
        products.put("Apple", 30);
        products.put("Beans", 50);
        products.put("Coke", 180);
        products.put("Deodorant", 250);
    }

    public void addItem(String item) {
        items.add(item);
    }

    public int getTotalPence() {
        int totalPence = 0;

        for (String item : items){
            totalPence += getItemCost(item);
        }

        totalPence -= getApplesDiscount();
        totalPence -= getDeodorantDiscount();

        return totalPence;
    }

    private int getItemCost(String item) {
        Integer itemPrice = products.get(item);
        if (itemPrice == null){
            throw new RuntimeException(String.format("Unknown item '%s' in basket", item));
        }

        return itemPrice;
    }

    private int getApplesDiscount() {
        int applesCount = getNumberOfItemsInBasket("Apple");

        return calculateDiscount(applesCount,4, 20);
    }

    private int getDeodorantDiscount() {
        int deodorantCount = getNumberOfItemsInBasket("Deodorant");

        return calculateDiscount(deodorantCount, 2, 50);
    }

    private static int calculateDiscount(int numberOfItems, int numberOfItemsToGetDiscount, int discount) {
        int batchesOfDiscountedItems = numberOfItems / numberOfItemsToGetDiscount ;

        return discount * batchesOfDiscountedItems;
    }

    private int getNumberOfItemsInBasket(String itemToFind) {
        int itemCount = 0;

        for(String item : items){
            if (item.equals(itemToFind)){
                itemCount++;
            }
        }
        return itemCount;
    }
}
