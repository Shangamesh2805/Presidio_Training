empty_tuple = ()

example_tuple = (1, "Hello", 3.14, True)

example_tuple2 = 1, "Hello", 3.14, True


# Accessing Tuple Elements
first_item = example_tuple[0]
last_item = example_tuple[-1]


# Slicing Tuple
sub_tuple = example_tuple[1:3]

#Tuple Methods

count_example = example_tuple.count(3.14)  
index_example = example_tuple.index("Hello")

print(count_example,index_example)


#nested tuple

nested_tuple = (1, (2, 3), (4, 5, 6))
print(nested_tuple[1]) 
print(nested_tuple[1][1])


#Converting Between Tuples and Lists

list_example = [1, 2, 3]
tuple_from_list = tuple(list_example)

tuple_example = (4, 5, 6)
list_from_tuple = list(tuple_example)



