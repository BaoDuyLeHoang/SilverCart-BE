import React, { useState, useEffect } from 'react';
import axios from 'axios';

const host = process.env.REACT_APP_GHN_HOST;
const token = process.env.REACT_APP_GHN_TOKEN;

function App() {
  // State for selected values
  const [provinces, setProvinces] = useState([]);
  const [districts, setDistricts] = useState([]);
  const [wards, setWards] = useState([]);
  
  // State for selected items
  const [selectedProvince, setSelectedProvince] = useState(null);
  const [selectedDistrict, setSelectedDistrict] = useState(null);
  const [selectedWard, setSelectedWard] = useState(null);

  // Loading states
  const [loading, setLoading] = useState({
    provinces: false,
    districts: false,
    wards: false
  });

  // Error states
  const [error, setError] = useState({
    provinces: null,
    districts: null,
    wards: null
  });

  // Fetch provinces on component mount
  useEffect(() => {
    const fetchProvinces = async () => {
      try {
        setLoading(prev => ({ ...prev, provinces: true }));
        const res = await axios({
          method: 'GET',
          url: `${host}/shiip/public-api/master-data/province`,
          headers: { token }
        });
        if (res.data.code === 200) {
          setProvinces(res.data.data);
          setError(prev => ({ ...prev, provinces: null }));
        }
      } catch (err) {
        setError(prev => ({ ...prev, provinces: err.message }));
      } finally {
        setLoading(prev => ({ ...prev, provinces: false }));
      }
    };
    fetchProvinces();
  }, []);

  // Fetch districts when province changes
  useEffect(() => {
    if (!selectedProvince) {
      setDistricts([]);
      setSelectedDistrict(null);
      return;
    }

    const fetchDistricts = async () => {
      try {
        setLoading(prev => ({ ...prev, districts: true }));
        const res = await axios({
          method: 'GET',
          url: `${host}/shiip/public-api/master-data/district`,
          headers: { token },
          params: { province_id: selectedProvince.ProvinceID }
        });
        if (res.data.code === 200) {
          setDistricts(res.data.data);
          setError(prev => ({ ...prev, districts: null }));
        }
      } catch (err) {
        setError(prev => ({ ...prev, districts: err.message }));
      } finally {
        setLoading(prev => ({ ...prev, districts: false }));
      }
    };
    fetchDistricts();
  }, [selectedProvince]);

  // Fetch wards when district changes
  useEffect(() => {
    if (!selectedDistrict) {
      setWards([]);
      setSelectedWard(null);
      return;
    }

    const fetchWards = async () => {
      try {
        setLoading(prev => ({ ...prev, wards: true }));
        const res = await axios({
          method: 'GET',
          url: `${host}/shiip/public-api/master-data/ward`,
          headers: { token },
          params: { district_id: selectedDistrict.DistrictID }
        });
        if (res.data.code === 200) {
          setWards(res.data.data);
          setError(prev => ({ ...prev, wards: null }));
        }
      } catch (err) {
        setError(prev => ({ ...prev, wards: err.message }));
      } finally {
        setLoading(prev => ({ ...prev, wards: false }));
      }
    };
    fetchWards();
  }, [selectedDistrict]);

  // Handle selection changes
  const handleProvinceChange = (e) => {
    const province = provinces.find(p => p.ProvinceID === Number(e.target.value));
    setSelectedProvince(province || null);
  };

  const handleDistrictChange = (e) => {
    const district = districts.find(d => d.DistrictID === Number(e.target.value));
    setSelectedDistrict(district || null);
  };

  const handleWardChange = (e) => {
    const ward = wards.find(w => w.WardCode === e.target.value);
    setSelectedWard(ward || null);
  };

  return (
    <div className="ghn-address-selector" style={{ padding: 20 }}>
      <h2>Chọn địa chỉ giao hàng</h2>
      
      {/* Selected Values Display */}
      {(selectedProvince || selectedDistrict || selectedWard) && (
        <div className="selected-address" style={{ margin: '10px 0' }}>
          <strong>Địa chỉ đã chọn:</strong><br />
          {selectedWard?.WardName}, {selectedDistrict?.DistrictName}, {selectedProvince?.ProvinceName}
          <div></div>
          {selectedWard?.WardCode}, {selectedDistrict?.DistrictID}, {selectedProvince?.ProvinceID}
        </div>
      )}

      {/* Province Selection */}
      <div className="select-group" style={{ marginBottom: 10 }}>
        <label style={{ display: 'block', marginBottom: 5 }}>Tỉnh/Thành phố:</label>
        <select 
          onChange={handleProvinceChange} 
          value={selectedProvince?.ProvinceID || ''}
          disabled={loading.provinces}
          style={{ width: '100%', padding: '8px' }}
        >
          <option value="">-- Chọn Tỉnh/Thành phố --</option>
          {provinces.map(province => (
            <option key={province.ProvinceID} value={province.ProvinceID}>
              {province.ProvinceName}
            </option>
          ))}
        </select>
        {error.provinces && <div style={{ color: 'red' }}>{error.provinces}</div>}
      </div>

      {/* District Selection */}
      <div className="select-group" style={{ marginBottom: 10 }}>
        <label style={{ display: 'block', marginBottom: 5 }}>Quận/Huyện:</label>
        <select 
          onChange={handleDistrictChange}
          value={selectedDistrict?.DistrictID || ''}
          disabled={!selectedProvince || loading.districts}
          style={{ width: '100%', padding: '8px' }}
        >
          <option value="">-- Chọn Quận/Huyện --</option>
          {districts.map(district => (
            <option key={district.DistrictID} value={district.DistrictID}>
              {district.DistrictName}
            </option>
          ))}
        </select>
        {error.districts && <div style={{ color: 'red' }}>{error.districts}</div>}
      </div>

      {/* Ward Selection */}
      <div className="select-group" style={{ marginBottom: 10 }}>
        <label style={{ display: 'block', marginBottom: 5 }}>Phường/Xã:</label>
        <select 
          onChange={handleWardChange}
          value={selectedWard?.WardCode || ''}
          disabled={!selectedDistrict || loading.wards}
          style={{ width: '100%', padding: '8px' }}
        >
          <option value="">-- Chọn Phường/Xã --</option>
          {wards.map(ward => (
            <option key={ward.WardCode} value={ward.WardCode}>
              {ward.WardName}
            </option>
          ))}
        </select>
        {error.wards && <div style={{ color: 'red' }}>{error.wards}</div>}
      </div>

      {/* Loading indicators */}
      {(loading.provinces || loading.districts || loading.wards) && (
        <div style={{ color: 'blue' }}>Đang tải...</div>
      )}
    </div>
  );
}

export default App;
