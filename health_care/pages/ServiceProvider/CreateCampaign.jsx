import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';

import { useAuth } from '../AuthContext';
import ServiceProviderNav from "./ServiceProviderNav";
import SessionCheck from "../Session";


const CreateCampaign = () => {
  const router = useRouter();
  const [name, setname] = useState('');
  const [start, setstart] = useState('');
  const [end, setend] = useState('');
  const [location, setlocation] = useState(null);
  const [description, setdescription] = useState(null);
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});
  const { user, login, logout, Tkey } = useAuth() || {}; 
  

  const handleNameChange = (e) => {
    setname(e.target.value);
  };

  const handleStartChange = (e) => {
    setstart(e.target.value);
  };

  const handleEndChange = (e) => {
    setend(e.target.value);
  };
  const handleLocationChange = (e) => {
    setlocation(e.target.value);
  };
  const handleDescriptionChange = (e) => {
    setdescription(e.target.value);
  };



  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name) {
      setFormErrors({ name: 'Please enter  name' });
    } else if(!location){
      setFormErrors({ location: 'Please enter phone number' });
    } else {
      setFormErrors({});

      try {
        const formData = new FormData();
        formData.append('CampaignName', name);
        formData.append('StartDate', start);
        formData.append('EndDate', end);
        formData.append('Location', location);
        formData.append('Description', description);
       

        const response = await axios.post(
          'https://localhost:44307/api/BloodDonationCampaign/AddCampaign',
          formData,
          {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `${Tkey}`,
               
            },
          }
        );

        console.log("Backend Response:", response);

        if (response.data === "Invalid product") {
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
      <div className="bg-white p-8 rounded shadow-md w-96">
        <h2 className="text-2xl font-bold mb-1 text-center">ADD CAMPAIGN</h2>
        <form onSubmit={handleSubmit} encType="multipart/form-data">
          <div className="mb-1">
            <input
              type="text"
              id="name"
              name="name"
              placeholder="Campaign Name"
              value={name}
              onChange={handleNameChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.name ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.name && (
              <p className="text-red-500 text-sm mt-1">{formErrors.name}</p>
            )}
          </div>
          <div className="mb-1">
            <input
              type="date"
              id="start"
              name="start"
              placeholder="StartDate"
              value={start}
              onChange={handleStartChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.start ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.start && (
              <p className="text-red-500 text-sm mt-1">{formErrors.start}</p>
            )}
          </div>
          
          <div className="mb-1">

            <input
              type="date"
              id="end"
              name="end"
              placeholder="End Date"
              value={end}
              onChange={handleEndChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.end ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.end && (
              <p className="text-red-500 text-sm mt-1">{formErrors.end}</p>
            )}
          </div>

          <div className="mb-1">
            <input
  type="text"
  id="location"
  placeholder=" Location"
  name="location"
  onChange={handleLocationChange}
  className={`w-full p-3 border rounded-md focus:outline-none ${
    formErrors.location ? "border-red-500" : "border-gray-300"
  }`}
/>
            {formErrors.location && (
              <p className="text-red-500 text-sm mt-1">{formErrors.location}</p>
            )}
          </div>
          <div className="mb-1">
            <input
              type="text"
              placeholder=" Description"
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
            className="bg-blue-500 text-white w-full align-middle px-4 py-2 rounded-sm hover:bg-blue-600 transition duration-300"
          >
            ADD Campaign
          </button>
        </form>
        {error && <p className="text-red-500 mt-4">{error}</p>}
      </div>
    </div>
    </div>
    </div>
  );
};

export default CreateCampaign;




