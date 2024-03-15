// ContactUsPage.jsx
import React, { useState } from "react";

const Contact = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    message: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your logic here to handle the form submission, such as sending an email or saving to a database
    console.log("Form submitted:", formData);
    // You can also reset the form fields if needed
    setFormData({
      name: "",
      email: "",
      message: "",
    });
  };

  return (
    <div className="bg-gradient-to-r from-[#F0F7F6] to-[#e1e8e7] min-h-screen flex flex-col justify-center items-center">
      <div className="-w-full max-w-6xl p-12 bg-white rounded-md shadow-lg mt-5">
        
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
        
          <div>
          <h1 className="text-2xl font-bold  text-[#56b5a9] mt-4">
          Contact Us
        </h1>
            <p className="text-lg mb-4 text-gray-700">
              Have questions or need assistance? Feel free to reach out to us
              using the contact form or the information below:
            </p>
            <p className="text-lg text-gray-700">
              <strong>Email:</strong> info@bustracker.com
            </p>
            <p className="text-lg text-gray-700">
              <strong>Phone:</strong> (123) 456-7890
            </p>
            <p className="text-lg text-gray-700">
              <strong>Address:</strong> 123 Bus Lane, Cityville, State
            </p>
            <div className="mt-4">
              <p className="text-lg mb-2 text-gray-700">
                Connect with us on social media:
              </p>
              <div className="flex space-x-4">
                <a
                  href="#"
                  className="text-blue-500 hover:text-blue-700"
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  Facebook
                </a>
                <a
                  href="#"
                  className="text-blue-500 hover:text-blue-700"
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  Twitter
                </a>
              </div>
            </div>
          </div>
          <div>
            <form onSubmit={handleSubmit}>
              <div className="mb-4">
                <label
                  htmlFor="name"
                  className="block text-lg font-semibold mb-2 text-gray-700"
                >
                  Name:
                </label>
                <input
                  type="text"
                  id="name"
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-blue-500"
                  required
                />
              </div>
              <div className="mb-4">
                <label
                  htmlFor="email"
                  className="block text-lg font-semibold mb-2 text-gray-700"
                >
                  Email:
                </label>
                <input
                  type="email"
                  id="email"
                  name="email"
                  value={formData.email}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-blue-500"
                  required
                />
              </div>
              <div className="mb-4">
                <label
                  htmlFor="message"
                  className="block text-lg font-semibold mb-2 text-gray-700"
                >
                  Message:
                </label>
                <textarea
                  id="message"
                  name="message"
                  value={formData.message}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-blue-500 resize-none"
                  rows="4"
                  required
                />
              </div>
              <button
                type="submit"
                className="bg-blue-500 text-white px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
              >
                Submit
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Contact;
