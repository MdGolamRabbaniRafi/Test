import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
import { useAuth } from "../AuthContext";
import Image from 'next/image';
import Link from "next/link";


const Login = () => {
  const auth = useAuth();
  console.log('Auth context:', auth);

  const { login } = auth || {};
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [generalError, setGeneralError] = useState("");
  const router = useRouter();
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const [formErrors, setFormErrors] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });

    setFormErrors({
      ...formErrors,
      [e.target.name]: "", // Clear any previous errors when the user starts typing
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    // Perform form validation
    let isValid = true;
    const newFormErrors = { ...formErrors };
  
    if (formData.email.trim() === "") {
      newFormErrors.email = "Email is required";
      isValid = false;
    }
  
    if (formData.password.trim() === "") {
      newFormErrors.password = "Password is required";
      isValid = false;
    }
  
    if (!isValid) {
      setFormErrors(newFormErrors);
      return;
    }
  
    try {
      const response = await axios.post(
        'https://localhost:44307/api/login',
        {
            Email: formData.email,
          Password: formData.password,
        },
        {
          headers: {
            'Content-Type': 'application/json',
          },
          withCredentials: true,
        }
      );
  
      if (response.data.error === "PasswordMismatchError") {
        setPasswordError("Incorrect password. Please try again.");
        setEmailError("");
      } else if (response.data.error === "EmailMismatchError") {
        setEmailError("Email and password do not match. Please try again.");
        setPasswordError("");
      } else {
        console.log("Login success:", response);
        console.log("cookies" + response.data.Tkey);
        login(response.data.UserId,response.data.Tkey);
        console.log("email" + response.data.UserId)
        var checkuser= response.data.UserType;
        console.log("Check User Type:"+ checkuser)
        if(checkuser == "User"){
          router.push('/User/UserDashboard');
        }
        else if(checkuser == "ServiceProvider"){
          router.push('/ServiceProvider/ServiceProviderDashboard');
        }
        else{
          router.push('/Admin/AdminDashboard');
        }
       
      }
    } catch (error) {
      console.log("Error:", error);
      setGeneralError("Email and password do not match. Please try again.");
    }
  };
  
  return (
    
    <div className="flex justify-center items-center h-screen bg-[#79b1b1]">
      
      <div className="bg-white h-[400px] rounded shadow-md w-[1000px] flex flex-row">
        <div className="">
        
        <Image
          src="/login.jpg"
          alt="signup"
          width={650}  // Set the width of the image
          height={200}  // Set the height of the image
        />
      
        </div>
        <div className="h-[300px] w-[300px]">
        <h2 className="text-4xl font-bold mb-6 mt-8 text-center text-gray-700">LOGIN</h2>
        
        <form onSubmit={handleSubmit}>
          <div className="mb-2">
            
            <input
              type="text"
              id="email"
              name="email"
              placeholder="Enter Email"
              value={formData.email}
              onChange={handleChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.email ? "border-red-500" : "border-gray-300"
              }`}
              
            />
            {formErrors.email && (
              <p className="text-red-500 text-sm mt-1">{formErrors.email}</p>
            )}
          </div>
          <div className="mb-2">
            
            <input
              type="password"
              id="password"
              name="password"
              placeholder="Password"
              value={formData.password}
              onChange={handleChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.password ? "border-red-500" : "border-gray-300"
              }`}
              
             
            />
           
            {formErrors.password && (
              <p className="text-red-500 text-sm mt-1">{formErrors.password}</p>
            )}
             {emailError && (
            <p className="text-red-500 text-sm mt-1">{emailError}</p>
          )}
          {passwordError && (
            <p className="text-red-500 text-sm mt-1">{passwordError}</p>
          )}
          {generalError && (
            <p className="text-red-500 text-sm mt-1">{generalError}</p>
          )}
          </div>
          <button
            type="submit"
            className="bg-[#38ada9] text-white px-4 py-2 w-full rounded-sm hover:bg-blue-600 transition duration-300"
          >
            Login
          </button>
        </form>
        <Link href="/Auth/Registration"><h2 className="text-gray-500 text-center mb-[5px] ">Don't have an account? <span className='text-blue-500'>Signup here</span> </h2></Link>


        </div>
        
      </div>
    </div>
  );
};

export default Login;
