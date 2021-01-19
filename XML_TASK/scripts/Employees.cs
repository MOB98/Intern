
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Employees
{

    private EmployeesEmployee[] employeeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Employee")]
    public EmployeesEmployee[] Employee
    {
        get
        {
            return this.employeeField;
        }
        set
        {
            this.employeeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class EmployeesEmployee
{

    private EmployeesEmployeeChild childField;

    private EmployeesEmployeeFullAddress fullAddressField;

    private object hobbiesField;

    private string nameField;

    private string departmentField;

    private System.DateTime birthdateField;

    private string hiredateField;

    /// <remarks/>
    public EmployeesEmployeeChild Child
    {
        get
        {
            return this.childField;
        }
        set
        {
            this.childField = value;
        }
    }

    /// <remarks/>
    public EmployeesEmployeeFullAddress FullAddress
    {
        get
        {
            return this.fullAddressField;
        }
        set
        {
            this.fullAddressField = value;
        }
    }

    /// <remarks/>
    public object Hobbies
    {
        get
        {
            return this.hobbiesField;
        }
        set
        {
            this.hobbiesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string department
    {
        get
        {
            return this.departmentField;
        }
        set
        {
            this.departmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime birthdate
    {
        get
        {
            return this.birthdateField;
        }
        set
        {
            this.birthdateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hiredate
    {
        get
        {
            return this.hiredateField;
        }
        set
        {
            this.hiredateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class EmployeesEmployeeChild
{

    private string nameField;

    private string genderField;

    private string birthdateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string gender
    {
        get
        {
            return this.genderField;
        }
        set
        {
            this.genderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string birthdate
    {
        get
        {
            return this.birthdateField;
        }
        set
        {
            this.birthdateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class EmployeesEmployeeFullAddress
{

    private string streetField;

    private string cityField;

    private uint phonenumberField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string street
    {
        get
        {
            return this.streetField;
        }
        set
        {
            this.streetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string city
    {
        get
        {
            return this.cityField;
        }
        set
        {
            this.cityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint phonenumber
    {
        get
        {
            return this.phonenumberField;
        }
        set
        {
            this.phonenumberField = value;
        }
    }
}

