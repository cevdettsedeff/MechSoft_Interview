#size_multiply_with_occurrence_Solution.py

def find_max(t, z):
    max_value = 0  # Maksimum değeri başlangıçta sıfır olarak ayarladım.
    t_length = len(t)

    # T'nin tüm alt dizilerini oluştur
    for i in range(t_length):
        for j in range(i + 1, t_length + 1):
            substring = t[i:j]  # T'nin alt dizesini aldım.

            # Z içinde bu alt dizenin kaç kez geçtiğini saydım.
            occurrences = z.count(substring)

            # Eğer bulunan alt dize Z içinde en az bir kez geçiyorsa bu işleme girdim.
            if occurrences > 0:
                current_value = len(substring) * occurrences  # Alt dize değerini hesapladım.

                # Eğer bulunan alt dize değeri mevcut maksimum değerden büyükse güncelledim.
                if current_value > max_value:
                    max_value = current_value

    return max_value


if __name__ == '__main__':
    result = find_max("acldm1labcdhsnd", "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa")
    print(result)