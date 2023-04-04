// Lặp qua từng phần tử có class "countdown"
document.querySelectorAll('.countdown').forEach(element => {
    // Lấy ngày hết hạn từ thuộc tính "data-expiry" của thẻ span
    const expiryDate = new Date(element.getAttribute('data-expiry'));

    // Tính số ngày còn lại từ ngày hiện tại đến ngày hết hạn
    const remainingDays = Math.ceil((expiryDate - new Date()) / (1000 * 60 * 60 * 24));

    // Hiển thị số ngày còn lại
    element.textContent = `Còn ${remainingDays} ngày để ứng tuyển`;
});