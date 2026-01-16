1. orders[customer_id][item] = new_price


2. orders[customer_id][new_item] = price


3. {k: v * 1.10 for k, v in order.items()}


4. sum(order.values())


5. order.pop(item_name)


6. order.update(other_dict)


7. order.get(item_name, 0)


8. 'Pizza' in order


9. order[item] = price


10. for customer, order in orders.items(): print(sum(order.values()))


11. order.popitem()


12. Last inserted item, because dictionaries are insertion-ordered


13. order[wrong_item] = correct_price


14. order.update(new_items)


15. order.clear() → dictionary becomes empty


