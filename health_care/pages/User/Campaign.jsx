import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import { useAuth } from '../AuthContext';
import UserNav from './UserNav';

const Campaign = () => {
  const router = useRouter();
  const [allCampaign, setAllCampaign] = useState([]);
  const [error, setError] = useState('');
  const { user, login, logout, Tkey } = useAuth() || {}; 

  useEffect(() => {
    // Fetch products when the component mounts
    GetLandpost();
  }, []);

  const GetLandpost = async () => {
    try {
      const response = await axios.get(
        'https://localhost:44307/api/GetTotalAvailableCampaigns',
        {
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `${Tkey}`,
          },
        }
      );
      console.log(response.data)
      console.log(response.success)
      if (response.data) {
        console.log('Products:', response.data);
        console.log(response.data.data);
        setAllCampaign(response.data);
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
  };

  const handleDetailsClick = (id) => {
    console.log("land id" + id);
    router.push(`./LandPostDetails/${id}`);
  };

  const handleContactClick = () => {
    router.push(`/SendEmailManager/`);
  };
  return (
    <div>
      <UserNav />
    <div className="bg-[#dfe4ea] text-white min-h-screen py-12">
      <div className="container mx-auto">
        <h2 className="text-4xl font-bold mb-8 text-center text-[#303952]">Campaign</h2>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-2  ">
          {allCampaign.length > 0 ? (
            allCampaign.map((landpost) => (
              <div key={landpost.Id} className="bg-[#f4f6ff] w-80 ml-10 overflow-hidden shadow-lg transition-transform transform hover:scale-105 rounded-md">
                <div className="p-8">
                  <h3 className="text-2xl font-semibold text-[#0c1118] mb-1"><span className='text-2xl'>Name :</span>{landpost.CampaignName}</h3>
                  <p className="text-gray-800 mb-4"> <span className='text-2xl'>Start :</span>{landpost.StartDate}</p>
                  <div className="flex items-center justify-between mb-1">
                    
                      
                    <p className="text-sm text-gray-800 mr-2"><span className='text-2xl'>End : </span>{landpost.EndDate}</p>
                    </div>
                    <p className="text-xl font-semibold text-gray-800">Location :{landpost.Location}</p><br />
                    <p className="text-xl font-semibold text-gray-800">Description :{landpost.Description}</p>
                 
                  {/* Action buttons */}
                  <div className="justify-center mt-5">
                    <button className="bg-[#0984e3] hover:bg-blue-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer mr-2"
                      onClick={handleContactClick}
                    >
                      Join Campaign
                    </button>
                    
                  </div>
                </div>
              </div>
            ))
          ) : (
            <div className="text-center text-gray-300">No Campaign</div>
          )}
        </div>
      </div>
    </div>
    </div>
  )
}

export default Campaign

