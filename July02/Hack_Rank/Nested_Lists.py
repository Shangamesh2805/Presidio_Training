if __name__ == '__main__':
    dic={}
    num_students = int(input())
    
   
    students = []
    

    for _ in range(num_students):
        name = input().strip()
        grade = float(input().strip())
        students.append([name, grade])
    
    grades = sorted(set(student[1] for student in students))
    second_lowest_grade = grades[1]

    second_lowest_students = sorted(student[0] for student in students if student[1] == second_lowest_grade)

    for student in second_lowest_students:
        print(student)
