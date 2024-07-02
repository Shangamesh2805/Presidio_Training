# file_handling

def write_to_file(filename, content):
    try:
        with open(filename, 'w') as file:
            file.write(content)
        print(f"Content written to {filename}")
    except IOError as e:
        print(f"Error writing to file: {e}")

def append_to_file(filename, content):
    try:
        with open(filename, 'a') as file:
            file.write(content)
        print(f"Content appended to {filename}")
    except IOError as e:
        print(f"Error appending to file: {e}")

def read_from_file(filename):
    try:
        with open(filename, 'r') as file:
            content = file.read()
        print(f"Content read from {filename}:")
        print(content)
    except FileNotFoundError:
        print(f"Error: {filename} not found.")
    except IOError as e:
        print(f"Error reading from file: {e}")

def main():
    filename = "file.txt"
    initial_content = "Hello, this is a test file.\n"
    additional_content = "This is some additional content.\n"

 
    write_to_file(filename, initial_content)

   
    read_from_file(filename)

    
    append_to_file(filename, additional_content)

    
    read_from_file(filename)

if __name__ == "__main__":
    main()
