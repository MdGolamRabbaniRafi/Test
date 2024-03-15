import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
import { useAuth } from '../AuthContext';
import ServiceProviderNav from './ServiceProviderNav'
import SessionCheck from "../Session";

const ProvideHelp = () => {
  const router = useRouter();
    const [userid, setuserid] = useState('');
    const [amount, setamount] = useState('');
    const [description, setdescription] = useState('');
    const [error, setError] = useState('');
    const [formErrors, setFormErrors] = useState({});
    const { user, login, logout, Tkey } = useAuth() || {}; 


    const handleUserIdChange = (e) => {
      setuserid(e.target.value);
    };
    const handleAmountChange = (e) => {
      setamount(e.target.value);
    };
  
    const handleDescriptionChange = (e) => {
      setdescription(e.target.value);
    };

    const handleSubmit = async (e) => {
      e.preventDefault();
  
      if (!amount) {
        setFormErrors({ product: 'Please enter  amount' });
      } else if(!description){
        setFormErrors({ product_price: 'Please enter description' });
      } else {
        setFormErrors({});
  
        try {
          const formData = new FormData();
          formData.append('UserId', userid);
          formData.append('Amount', amount);
          formData.append('Description', description);
  
          const response = await axios.post(
            'https://localhost:44307/api/User/Donate',
            formData,
            {
              headers: {
                  'Content-Type': 'application/json',
                  'Authorization': `${Tkey}`,
              },
            }
          );
  
          console.log("Backend Response:", response);
  
          if (response.data === "Invalid ") {
            setError('Product is invalid');
          } else {
            router.push('/ServiceProvider/ServiceProviderDashboard');
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
      }
    };
    return (
      <div>
           <SessionCheck />  
      <ServiceProviderNav />
      <div className='col-span-12 bg-[#dfe4ea] text-[#192a56] p-8 shadow-md'>
      <div className="flex justify-center items-center h-[80vh] bg-gray-100 mt-1">
        <div className="bg-white p-6  rounded shadow-md w-96">
          <h2 className="text-2xl font-bold ">Provide Help</h2>
          <form onSubmit={handleSubmit} encType="multipart/form-data">
          <div className="mb-2">
              <label htmlFor="product" className="block text-sm font-semibold text-gray-600 mb-1">
                 User Id:
              </label>
              <input
                type="text"
                id="userid"
                name="userid"
                value={userid}
                onChange={handleUserIdChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.userid ? "border-red-500" : "border-gray-300"
                }`}
              />
              {formErrors.userid && (
                <p className="text-red-500 text-sm mt-1">{formErrors.userid}</p>
              )}
            </div>
            <div className="mb-2">
              <label htmlFor="product" className="block text-sm font-semibold text-gray-600 mb-1">
                 Amount:
              </label>
              <input
                type="text"
                id="amount"
                name="amount"
                value={amount}
                onChange={handleAmountChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.amount ? "border-red-500" : "border-gray-300"
                }`}
              />
              {formErrors.amount && (
                <p className="text-red-500 text-sm mt-1">{formErrors.amount}</p>
              )}
            </div>
            <div className="mb-2">
              <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
                Description:
              </label>
              <input
                type="text"
                id="description"
                name="description"
                value={description}
                onChange={handleDescriptionChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.description ? "border-red-500" : "border-gray-300"
                }`}
              />
              {formErrors.description && (
                <p className="text-red-500 text-sm mt-1">{formErrors.description}</p>
              )}
            </div>
           
           
            <button
              type="submit"
              className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
            >
              Send
            </button>
          </form>
          {error && <p className="text-red-500 mt-4">{error}</p>}
        </div>
      </div>
      </div>
      </div>
    );
  };

export default ProvideHelp



