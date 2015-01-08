package io.github.leedscodedojo;

import org.junit.Test;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;
import static org.junit.Assert.fail;

public class BasketTests {
    Basket basket = new Basket();

    @Test
    public void empty_basket(){
        assertThat(basket.getTotalPence(), is(0));
    }

    @Test
    public void one_apple_in_basket() {
        basket.addItem("Apple");

        assertThat(basket.getTotalPence(), is(30));
    }

    @Test
    public void two_apples_in_basket() {
        basket.addItem("Apple");
        basket.addItem("Apple");

        assertThat(basket.getTotalPence(), is(60));
    }

    @Test
    public void unknown_item_in_basket() {
        basket.addItem("Pear");

        try{
            basket.getTotalPence();
            fail("Exception not thrown");
        }catch(RuntimeException ex){
            assertThat(ex.getMessage(), is("Unknown item 'Pear' in basket"));
        }
    }

    @Test
    public void one_beans_in_basket() {
        basket.addItem("Beans");

        assertThat(basket.getTotalPence(), is(50));
    }

    @Test
    public void lots_of_items_in_basket(){
        basket.addItem("Apple");
        basket.addItem("Beans");
        basket.addItem("Coke");
        basket.addItem("Deodorant");

        assertThat(basket.getTotalPence(), is(510));
    }

    @Test
    public void four_apples_give_discount() {
        addMultiItemsToBasket("Apple", 4);

        assertThat(basket.getTotalPence(), is(100));
    }

    @Test
    public void five_apples_give_discount() {
        addMultiItemsToBasket("Apple", 5);

        assertThat(basket.getTotalPence(), is(130));
    }

    @Test
    public void eight_apples_give_discount() {
        addMultiItemsToBasket("Apple", 8);

        assertThat(basket.getTotalPence(), is(200));
    }

    @Test
    public void two_deodorant_give_discount() {
        addMultiItemsToBasket("Deodorant", 2);

        assertThat(basket.getTotalPence(), is(450));
    }

    private void addMultiItemsToBasket(String item, int numberToAdd) {
        for(int i = 0 ; i < numberToAdd ; i++){
            basket.addItem(item);
        }
    }
}
