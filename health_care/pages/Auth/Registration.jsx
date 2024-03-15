import React, { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
import Link from 'next/link';
import Image from 'next/image';

const RegistrationForm = () => {
  const [formData, setFormData] = useState({
    FirstName: '',
    Email: '',
    DateOfBirth: '',
    Password: '',
    BloodGroup: '',
    UserType: '',
   
  });

  const [emailError, setEmailError] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post(
        'https://localhost:44307/api/User/add',
        {
          FirstName: formData.FirstName,
          Email: formData.Email,
          DateOfBirth: formData.DateOfBirth,
          Password: formData.Password,
          BloodGroup: formData.BloodGroup,
          UserType: formData.UserType,
          
        },
        {
          
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );

      console.log('Backend Response:', response);

      if (response.data) {
        console.log(response.data);
        router.push('/Auth/Login');
        
      } else {
        setEmailError('');
        setFormData({
          FirstName: '',
          Email: '',
          DateOfBirth: '',
          Password: '',
          BloodGroup: '',
          UserType: '',
         
        });
        router.push('./Auth/Login.jsx');
      }
    } catch (error) {
      console.error('Failed:', error);

      if (error.response) {
        console.log('Error Response Data:', error.response.data);
        console.log('Error Response Status:', error.response.status);
        console.log('Error Response Headers:', error.response.headers);
        setError(`Server error: ${error.response.status}`);
      } else if (error.request) {
        console.log('Error Request:', error.request);
        setError('Request to the server failed.');
      } else {
        console.log('Error Message:', error.message);
        setError('Something went wrong.');
      }
    }
  };

  return (
    <div>
     <div className='bg-white h-screen w-full flex'>
     <div className='bg-[#dee1e6] w-1/2 '>
       <h1 className='text-5xl text-[#22a6b3]  font-bold text-right mt-6'>HEALT</h1>
       <div className=' h-80 w-[500px] mt-8 ml-[180px]'>
       <div>
        <Image
          src="/signup.jpg"
          alt="signup"
          width={459}  // Set the width of the image
          height={80}  // Set the height of the image
        />
      </div>
       </div>
       </div>
       <div className='bg-[#22a6b3] w-1/2'>
        <h1 className='text-5xl text-white font-bold text-left mt-6'>HCARE</h1>
        <div className='bg-[#dfe4ea] h-96 w-[500px] mt-8 '>
        <div className=' h-80 w-[400px] absolute mt-1 ml-12'>
          <h1 className='text-3xl text-center font-bold'>Registration</h1>
          <form onSubmit={handleSubmit}>
          <div className='mt-2'>
           <input
          type="text"
          id="FirstName"
          name="FirstName"
          placeholder='Enter Full Name'
          value={formData.FirstName}
          onChange={handleChange}
          required
          className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-sm"
           />
           </div>

           <div className="mt-1">
        
        <input
          type="email"
          id="Email"
          name="Email"
          placeholder='Enter Email'
          value={formData.Email}
          onChange={handleChange}
          required
          className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-md"
        />
      </div>
      <div className="mt-1">
        
        <input
          type="date"
          id="DateOfBirth"
          name="DateOfBirth"
          placeholder='Date of Birth'
          value={formData.DateOfBirth}
          onChange={handleChange}
          required
          className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-md"
        />
      </div>
      <div className="mt-1">
       
        <input
          type="password"
          id="Password"
          name="Password"
          placeholder='Enter Password'
          value={formData.Password}
          onChange={handleChange}
          required
          className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-md"
        />
      </div>
      <div className="mt-1">
  <select
    id="BloodGroup"
    name="BloodGroup"
    value={formData.BloodGroup}
    onChange={handleChange}
    required
    className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-md"
  >
    <option value="" disabled>Select Blood Group</option>
    <option value="A+">A+</option>
    <option value="B+">B+</option>
    <option value="AB+">AB+</option>
    <option value="O+">O+</option>
    {/* Add more options as needed */}
  </select>
</div>

<div className="mt-1">
  <select
    id="UserType"
    name="UserType"
    value={formData.UserType}
    onChange={handleChange}
    required
    className="mt-1 p-1.5 w-full bg-[#d1d8e0] border rounded-md"
  >
    <option value="" disabled>Select User</option>
    <option value="Type1">User</option>
    <option value="Type2">ServiceProvider</option>
    {/* Add more options as needed */}
  </select>
</div>
      <div className="mt-1">
        <button
          type="submit"
          className="mt-1 p-1.5 w-full text-white bg-[#3487e7] "
        >
          Submit
        </button>
      </div>
      <div className="text-red-500">{emailError}</div>
      <div className="text-red-500">{error}</div>
      </form>  
      <Link href="/Auth/Login"><h2 className="text-gray-500 text-center mb-[5px] ">Already have an account? <span className='text-blue-500'>Login here</span> </h2></Link>
        </div>
        </div>
      </div>
       
     </div>

    
    </div>
    
  );
};

export default RegistrationForm;
