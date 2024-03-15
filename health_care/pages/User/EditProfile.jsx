// EditProfile.jsx
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
import UserNav from "./UserNav";
import { useAuth } from '../AuthContext';
import SessionCheck from "../Session";



const EditProfile = () => {
  const router = useRouter();
  const { profilePic } = router.query;
  const [profilePicture, setProfilPicture] = useState(profilePic || "");
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});
  const { Tkey } = useAuth() || {}; 
  

console.log("token", Tkey);
  const handlePictureChange = (e) => {
    const file = e.target.files[0];
    setProfilPicture(file);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    if (!profilePicture) {
      setFormErrors({
     
        profilePicture: 'Please select a profile picture',
      });
    } else {
      try {
        const formData = new FormData();
       
        formData.append('File', profilePicture);
  
        const response = await axios.post(
            'https://localhost:44307/api/UploadFile',
            formData,
            {
              headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': `${Tkey}`, // Include Tkey in the headers
              },
          }
        );
  
        console.log('Response:', response);
  
        if (response.data) {
          console.log('Profile updated successfully');
          router.push('/User/UserDashboard');
        } else {
          setError('Failed to update profile');
        }
      } catch (error) {
        console.error('Update failed:', error);
        if (error.response) {
          console.log('Response data:', error.response.data);
          console.log('Response status:', error.response.status);
          console.log('Response headers:', error.response.headers);
        }
        setError(`An error occurred while updating the profile: ${error.message}`);
      }
    }
  };
  
  
  

  return (
    <div>
      <SessionCheck />
      <UserNav />
      <div className="flex justify-center items-center h-screen bg-gray-100">
        <div className="bg-white p-8 rounded shadow-md w-96">
          <h2 className="text-2xl font-bold mb-6">EDIT PROFILE</h2>
          <form onSubmit={handleSubmit}>
           
            <div className="mb-2">
              <label htmlFor="profilePicture" className="block text-sm font-semibold text-gray-600 mb-1">
                Profile Picture:
              </label>
              <input
                type="file"
                id="profilePicture"
                name="profilePicture"
                onChange={handlePictureChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.profilePicture ? "border-red-500" : "border-gray-300"
                }`}
              />
              {formErrors.profilePicture && (
                <p className="text-red-500 text-sm mt-1">{formErrors.profilePicture}</p>
              )}
            </div>
            <button
              type="submit"
              className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
            >
              EDIT
            </button>
          </form>
          {error && <p className="text-red-500 mt-4">{error}</p>}
        </div>
      </div>
    </div>
  );
};

export default EditProfile;
